using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.utilities.results.implementations
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}