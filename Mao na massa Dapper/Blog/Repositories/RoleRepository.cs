﻿using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

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
            role.Id = 0;
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
                _connection.Update<Role>(role);

        }

        public void Delete(Role role)
        {
            if (role.Id != 0)
                _connection.Delete<Role>(role);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }
    }
}
