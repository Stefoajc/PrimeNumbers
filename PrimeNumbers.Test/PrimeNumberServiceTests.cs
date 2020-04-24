using NUnit.Framework;
using PrimeNumbers.Service;
using System;
using System.Collections.Generic;

namespace PrimeNumbers.Test
{
    public class Tests
    {

        public bool PrimeProperty(int number)
        {
            //0 or 1 are not considered primal
            if(number < 2) return false;

            //The number shouldn't be devidable by any of the numbers 
            //which are smaller than it except 1
            for (int i = number - 1; i > 1; i--)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            //Number is prime
            return true;
        }


        /// <summary>
        /// Property based testing based on alternative known working algoritm
        /// </summary>
        [Test]
        public void CheckPrimaltyProperty()
        {
            var rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 100; i++)
            {
                var number = rand.Next(-100, 100);

                Assert.IsTrue(PrimeProperty(number) == PrimeNumberService.IsPrime(number));
            }
        }


        /// <summary>
        /// Example based Testing
        /// </summary>
        [Test]
        public void ComparePrimalNumbersFromZeroToHundredWithTheFilteredFromTheMethodNumbers()
        {
            //Arrange
            int[] primalNumbersTo100 = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            List<int> primalNumbersFromMethod = new List<int>();

            //Act
            for (int i = 0; i < 100; i++)
            {
                if (PrimeNumberService.IsPrime(i))
                    primalNumbersFromMethod.Add(i);
            }

            //Assert
            Assert.IsTrue(primalNumbersTo100.Length == primalNumbersFromMethod.Count);

            for (int i = 0; i < primalNumbersTo100.Length; i++)
            {
                Assert.IsTrue(primalNumbersTo100[i] == primalNumbersFromMethod[i]);
            }
        }
    }
}