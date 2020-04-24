#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PrimeNumbers.Service/*.csproj", "PrimeNumbers.Service/"]
COPY ["PrimeNumbers.Api/*.csproj", "PrimeNumbers.Api/"]

RUN dotnet restore "PrimeNumbers.Api/PrimeNumbers.Api.csproj"
COPY . .

WORKDIR "/src/PrimeNumbers.Service"
RUN dotnet build "PrimeNumbers.Service.csproj" -c Release -o /app/build

WORKDIR "/src/PrimeNumbers.Api"
RUN dotnet build "PrimeNumbers.Api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "PrimeNumbers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrimeNumbers.Api.dll"]