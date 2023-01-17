using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Role> GetAll()
        {
            return _connection.GetAll<Role>();
        }

        public Role Get(int id)
        {
            return _connection.Get<Role>(id);
        }

        public void Create(Role role)
        {
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            _connection.Update<Role>(role);
        }

        public void Delete(Role role)
        {
            _connection.Delete<Role>(role);
        }
    }
}
