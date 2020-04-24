using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeNumbers.Service;

namespace PrimeNumbers.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PrimeNumbersController : ControllerBase
    {
        private readonly ILogger<PrimeNumbersController> _logger;

        public PrimeNumbersController(ILogger<PrimeNumbersController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get next prime number bigger than the passed
        /// </summary>
        /// <remarks>
        /// - Negative numbers are accepted but are considered not prime
        /// - Values up to 2147483647 are valid, but the next prime cannot be bigger than this it
        /// </remarks>
        /// <param name="number">number after which the prime will be returned</param>
        /// <returns>next prime after the specified number</returns>
        public ActionResult<int> NextPrime(int number)
        {
            var result = PrimeNumberService.NextPrime(number);

            return result.HasErrors switch
            {
                true => BadRequest(result.Errors),
                false => Ok(result.Value)
            };
        }

        /// <summary>
        /// Determines if the number is prime or not
        /// </summary>
        /// <remarks>
        /// - Negative numbers up to -2147483647 are accepted, but are considered not prime
        /// - Values up to 2147483647 are accepted
        /// </remarks>
        /// <param name="number"></param>
        /// <returns></returns>
        public ActionResult<bool> IsPrime(int number)
        {
            return Ok(PrimeNumberService.IsPrime(number));
        }
    }
}
