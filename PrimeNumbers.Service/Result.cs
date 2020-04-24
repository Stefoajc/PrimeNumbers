using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.Service
{
    public class Result<T>
    {
        public Result(T result)
        {
            Value = result;
        }

        public Result(List<string> errors)
        {
            Errors = errors;
        }

        public T Value { get; }

        public bool HasErrors
        {
            get
            {
                return Errors.Any();
            }
        }

        public List<string> Errors { get; private set; } = new List<string>();
    }
}
