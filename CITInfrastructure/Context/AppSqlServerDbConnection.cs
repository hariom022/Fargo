using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Context
{
    public class AppSqlServerDbConnection : IAppDbConnection
    {
        //public DbConnection dbConnection => throw new NotImplementedException();

        public DbConnection dbConnection
        {
            get
            {
                return _connection ??= CreateDbConnectiom();
            }
        }

        private DbConnection _connection;
        private readonly string _connectionString;

        public AppSqlServerDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        private DbConnection CreateDbConnectiom()
        {
            return new SqlConnection(_connectionString);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
