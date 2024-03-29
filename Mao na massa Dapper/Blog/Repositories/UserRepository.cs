﻿using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class UserRepository 
    { 
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.GetAll<User>();
        }

        public User Get(int id)
        {
            return _connection.Get<User>(id);
        }

        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        }

        public void Update(User user)
        {
            if(user.Id != 0)
            {
                _connection.Update<User>(user);
            }
        }

        public void Delete(User user)
        {
            if(user.Id != 0)
            {
                _connection.Delete<User>(user);
            }
        }

        // Nome igual Delete (método tem uma sobrecarga)
        public void Delete(int id)
        {
            if (id != 0)
                return;
            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }
}
