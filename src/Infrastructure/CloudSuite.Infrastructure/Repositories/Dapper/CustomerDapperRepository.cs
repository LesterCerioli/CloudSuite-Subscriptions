using CloudSuite.Modules.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories.Dapper
{
    public class CustomerDapperRepository
    {
        private readonly IConfiguration _config;

        public CustomerDapperRepository(IConfiguration config) 
        {
            _config = config;

        }

        public IEnumerable<Customer> GetAll()
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return db.Query<Customer>("SELECT * FROM Customer");
        }

        public IEnumerable<Customer> GetCustomerByCnpjAndEmail(string cnpj, string email)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            string query = "SELECT * FROM Customer WHERE Cnpj.CnpjNumber = @Cnpj AND Email.Address = @Email";
            return db.Query<Customer>(query, new { Cnpj = cnpj, Email = email });
        }
    }
}
