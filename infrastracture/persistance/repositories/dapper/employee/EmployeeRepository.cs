using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.genericrepositorybase.dapper;
using infrastracture.persistance.repositories.genericrepositorybase.dapper;
using Microsoft.Extensions.Configuration;

namespace infrastracture.persistance.repositories.dapper.employee
{
    public class EmployeeRepository : DapperGenericRepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

    }
}