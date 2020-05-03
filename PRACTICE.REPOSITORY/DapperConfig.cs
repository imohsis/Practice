using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PRACTICE.REPOSITORY
{
    public class DapperConfig
    {
        private IConfiguration _config;
        //private ProjectDbContet _ctx;
        public DapperConfig(IConfiguration config)
        {
            _config = config;
        }
        //public DapperConfig(ProjectDbContet ctx)
        //{
        //    _ctx = ctx;
        //}

        public IDbConnection ProjectDbConnection => new SqlConnection(_config.GetConnectionString("PracticeDB"));

    }
}