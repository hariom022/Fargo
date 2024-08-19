using CITApplication.Data;
using CITDomain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Data
{
    public class CITDbConnection : ICITDbConnection
    {
        public DbSet<UserModel> UserModels { get; set; }

        public DbConnection DbConnection
        {
            get
            {
                return _connection ?? CreateDbConnection();
            }
        }

        private DbConnection _connection;
        private readonly string _connectionString;

        public CITDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        private DbConnection CreateDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public void Dispose()
        {
            DbConnection.Dispose();
        }
        public async ValueTask DisposeAsync()
        {
            await DbConnection.DisposeAsync().ConfigureAwait(false);
        }
    }
}
