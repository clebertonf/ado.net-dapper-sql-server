using Mao_na_massa_Dapper.Blog.Crud;
using Microsoft.Data.SqlClient;
using System;

namespace Mao_na_massa_Dapper
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;Encrypt=False;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var connnection = new SqlConnection(CONNECTION_STRING);
            connnection.Open();

            // Users
            //MetodosCrud.ReadUsers(connnection);
            // MetodosCrud.ReadUser();
            // MetodosCrud.CreateUser();
            // MetodosCrud.UpdateUser();
            // MetodosCrud.DeleteUser();

            // Role
            MetodosCrud.ReadRole(connnection);

            connnection.Close();
        }
    }
}
