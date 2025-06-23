using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.utilities.results.interfaces
{
    public interface IDataResult<T>:IResult
    {
        public T Data { get;}
    }
}