using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Dapper;
using domain.interfaces.entity;
using domain.interfaces.genericrepositorybase.dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace infrastracture.persistance.repositories.genericrepositorybase.dapper
{
    public class DapperGenericRepositoryBase<T> : IDapperGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly string _connectionString;
        
        public DapperGenericRepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Oracle");
        }

        public async Task<IEnumerable<T>> GetAllAsync(string sql, object param = null)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(sql,param);
            }
        }
    }
}