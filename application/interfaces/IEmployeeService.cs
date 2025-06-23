using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;
using domain.utilities.results.interfaces;

namespace application.interfaces
{
    public interface IEmployeeService
    {
        Task<IDataResult<IEnumerable<Employee>>> GetAllEmployeeAsync();
    }
}