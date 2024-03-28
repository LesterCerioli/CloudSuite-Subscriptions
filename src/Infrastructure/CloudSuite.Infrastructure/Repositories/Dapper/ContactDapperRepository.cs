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
    public class ContactDapperRepository
    {
        private readonly IConfiguration _config;

        public ContactDapperRepository(IConfiguration config)
        {
            _config = config;

        }

        public IEnumerable<Contact> GetAll()
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return db.Query<Contact>("SELECT * FROM Contact");
        }

        public IEnumerable<Contact> GetContactByEmailNameAndTelephone(string email, string name, string telephone)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            string query = "SELECT * FROM Contact WHERE Email = @Email AND Name = @Name AND Telephone = @Telephone";
            return db.Query<Contact>(query, new { Email = email, Name = name, Telephone = telephone });
        }

    }
}
