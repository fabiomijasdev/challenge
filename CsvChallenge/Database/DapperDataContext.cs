using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Data;

namespace CsvChallenge.Database
{
    public class DapperDataContext
    {
        protected readonly IConfiguration _configuration;

        public DapperDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_configuration.GetConnectionString("sqlitedb"));
        }
    }
}
