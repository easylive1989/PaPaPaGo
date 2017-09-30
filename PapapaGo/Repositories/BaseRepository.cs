using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using MySql.Data.MySqlClient;

namespace PapapaGo.Repositories
{
    public class BaseRepository
    {
        protected DbConnection Connection;

        private readonly string _ConnectionString;

        protected BaseRepository(string connectionString)
        {
            _ConnectionString = connectionString;
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
        }

        public async Task ExecuteTransactionAsync(Func<Task<bool>> asyncAction)
        {
            using (var transaction = new TransactionScope())
            {
                var result = await asyncAction();
                if (!result)
                    transaction.Dispose();
                transaction.Complete();
            }
        }

        protected async Task<decimal> ExecuteAsync(string query, object param = null)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.ExecuteAsync(query, param, null, 0, CommandType.StoredProcedure);
            }
        }

        protected async Task<T> ExecuteScalarAsync<T>(string spName, object param = null)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.ExecuteScalarAsync<T>(spName, param);
            }
        }

        protected async Task<TResult> GetById<TResult>(object id)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.GetAsync<TResult>(id);
            }
        }

        protected IEnumerable<TResult> GetList<TResult>(string condition, object param = null)
        {
            using (var conn = GetDbConnection())
            {
                return conn.GetList<TResult>(condition, param);
            }
        }

        protected async Task<IEnumerable<TResult>> GetListAsync<TResult>(string condition, object param = null)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.GetListAsync<TResult>(condition, param);
            }
        }

        protected int? Insert(object entityObject)
        {
            using (var conn = GetDbConnection())
            {
                return conn.Insert(entityObject);
            }
        }

        protected async Task<int?> InsertAsync(object entityObject)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.InsertAsync(entityObject);
            }
        }

        protected async Task<T> QueryAsync<T>(string spName, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = GetDbConnection())
            {
                return (await conn.QueryAsync<T>(spName, param, null, null, commandType)).FirstOrDefault();
            }
        }

        protected async Task<IEnumerable<T>> QueryListAsync<T>(string spName, object param = null)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.QueryAsync<T>(spName, param, null, null, CommandType.StoredProcedure);
            }
        }

        protected async Task<int> UpdateAsync(object entityObject)
        {
            using (var conn = GetDbConnection())
            {
                return await conn.UpdateAsync(entityObject);
            }
        }

        private DbConnection GetDbConnection()
        {
            return new MySqlConnection(_ConnectionString);
        }
    }
}