using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.utilities.results.implementations
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}