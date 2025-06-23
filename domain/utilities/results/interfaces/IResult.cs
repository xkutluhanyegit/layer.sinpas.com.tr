using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.utilities.results.interfaces
{
    public interface IResult
    {
        public string Message { get;}
        public bool Success { get; }
    }
}