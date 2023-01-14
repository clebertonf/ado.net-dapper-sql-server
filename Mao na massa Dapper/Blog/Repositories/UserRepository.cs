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
        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.GetAll<User>();
            }
        }
    }
}
