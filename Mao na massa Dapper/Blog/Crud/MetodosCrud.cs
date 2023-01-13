using Dapper.Contrib.Extensions;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Mao_na_massa_Dapper.Blog.Crud
{
    public class MetodosCrud
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;Encrypt=False;User ID=sa;Password=1q2w3e4r@#$";
        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
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
    }
}
