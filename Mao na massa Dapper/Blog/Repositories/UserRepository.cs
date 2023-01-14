using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class UserRepository 
    { 
        private SqlConnection _connection = new SqlConnection();
        public IEnumerable<User> GetAll(string connectionString)
        {
            return _connection.GetAll<User>();
        }

        public User Get(int id)
        {
            return _connection.Get<User>(id);
        }

        public void Create(User user)
        {
            _connection.Insert<User>(user);
        }

        public void Delete(User user)
        {
            _connection.Delete<User>(user);
        }
    }
}
