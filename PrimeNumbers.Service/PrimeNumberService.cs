using System;
using System.Collections.Generic;

namespace PrimeNumbers.Service
{
    public static class PrimeNumberService
    {
        public static Result<int> NextPrime(int number)
        {
            for (int i = number + 1; i < int.MaxValue; i++)
            {
                if (IsPrime(i))
                    return new Result<int>(i);
            }

            return new Result<int>(new List<string> { $"Prime numbers supported up to {int.MaxValue}" });
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
