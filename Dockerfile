#Use the following command
#
#docker run -p 5000:5000 -e ASPNETCORE_URLS=http://+:5000 --name alias imagename
#     host port^    ^container port

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "PrimeNumbers.sln" "./"
COPY ["PrimeNumbers.Api/*.csproj", "./PrimeNumbers.Api/"]
COPY ["PrimeNumbers.Service/*.csproj", "./PrimeNumbers.Service/"]
COPY ["PrimeNumbers.Test/*.csproj", "./PrimeNumbers.Test/"]

RUN dotnet restore
COPY . .

WORKDIR "/src/PrimeNumbers.Service"
RUN dotnet build -c Release -o /app

WORKDIR "/src/PrimeNumbers.Api"
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish "PrimeNumbers.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PrimeNumbers.Api.dll"]