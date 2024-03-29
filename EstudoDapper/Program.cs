﻿using EstudoDapper.Metodos_Base;
using Microsoft.Data.SqlClient;

namespace DataAccessProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;Encrypt=False;User ID=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {
                // MetodosBaseDapper.UpdateCategorie(connection);
                // MetodosBaseDapper.ListCategories(connection);
                // MetodosBaseDapper.InsertCategorie(connection);
                // MetodosBaseDapper.DeleteCategory(connection);
                // MetodosBaseDapper.ListCategoryId(connection);
                // MetodosBaseDapper.InsertManyCategoryes(connection);
                // MetodosBaseDapper.ExecuteProcedureDeleteStudent(connection);
                // MetodosBaseDapper.ExecuteProcedureReadCoursesByCategoryID(connection);
                //  MetodosBaseDapper.ExecuteScalar(connection);
                // MetodosBaseDapper.ExecuteViews(connection);
                // MetodosBaseDapper.OneToOne(connection);
                // MetodosBaseDapper.OneToMany(connection);
                // MetodosBaseDapper.QueryMutiple(connection);
                // MetodosBaseDapper.SelectIn(connection);
                // MetodosBaseDapper.Like(connection);
                MetodosBaseDapper.Transaction(connection);
            }
        }
    }
}