using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace University.Persistence
{
    public class UniversityContextDapper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UniversityContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
