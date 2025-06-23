using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.interfaces.entity;

namespace domain.interfaces.genericrepositorybase.dapper
{
    public interface IDapperGenericRepositoryBase<T> where T:class,IEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync(string sql,object param = null);
    }
}