using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.genericrepositorybase.dapper;
using infrastracture.externalservices.meyerapi.models;

namespace infrastracture.persistance.repositories.dapper.employee
{
    public interface IEmployeeRepository:IDapperGenericRepositoryBase<Employee>
    {
        
    }
}