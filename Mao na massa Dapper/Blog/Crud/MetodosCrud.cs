using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Mao_na_massa_Dapper.Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;

namespace Mao_na_massa_Dapper.Blog.Crud
{
    public class MetodosCrud
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;Encrypt=False;User ID=sa;Password=1q2w3e4r@#$";
        public static void ReadUsers()
        {
            var repository = new UserRepository();
            var users = repository.GetAll(CONNECTION_STRING);

            foreach (var user in users )
            {
                Console.WriteLine(user.Name);
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                
                Console.WriteLine(user.Name);

            }
        }

        public static void CreateUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = new User()
                {
                    Image = "https://...",
                    Bio = "Katrine",
                    Name = "Katrine Carvalho",
                    Email = "Katrine@gmail.com",
                    PasswordHash = "Hash",
                    slug = "katrine-carvalho"
                };

                var rows = connection.Insert<User>(user);

                Console.WriteLine(rows);

            }
        }

        public static void UpdateUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = new User()
                {
                    Id = 2,
                    Image = "https://...",
                    Bio = "Katrine pereira",
                    Name = "Katrine Carvalho",
                    Email = "KatrinePereira@gmail.com",
                    PasswordHash = "Hash",
                    slug = "katrine-carvalho"
                };

                var rows = connection.Update<User>(user);

                Console.WriteLine(rows);

            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(5);
                var rows = connection.Delete<User>(user);

                Console.WriteLine(rows);

            }
        }
    }
}
