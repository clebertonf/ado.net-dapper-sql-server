using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.GetAll<User>();
        }
    }
}
