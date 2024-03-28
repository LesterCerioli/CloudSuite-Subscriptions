using CloudSuite.Modules.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories.Dapper
{
    public class CompanyDapperRepository
    {

        private readonly string _connectionString;

        public CompanyDapperRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public IEnumerable<Company> GetAllCompanies()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Company>("SELECT * FROM Company");
        }

        public Company GetCompanyById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Company>("SELECT * FROM Company WHERE Id = @Id", new { Id = id });
        }
    }
}
