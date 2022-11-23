using Dapper;
using EstudoDapper.Models;
using Microsoft.Data.SqlClient;
using System;

namespace EstudoDapper.Metodos_Base
{
    public static class MetodosBaseDapper
    {
        public static void ListCategories(SqlConnection connection)
        {
            // select
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        public static void ListCategoryId(SqlConnection connection)
        {
            var category = connection.QueryFirstOrDefault<Category>("SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id]=@id", new
            {
                id = "6cd9ba03-5521-43fa-8275-553fd5ca042a"
            });

            Console.WriteLine($"{category.Id} - {category.Title}");
        }

        public static void InsertCategorie(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                [Category]
             VALUES(
                  @Id,
                  @Title,
                  @Url,
                  @Summary,
                  @Order,
                  @Description,
                  @Featured)";

            // Insert
            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine(rows);
        }

        public static void UpdateCategorie(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} registros atualizados");
        }

        public static void DeleteCategory(SqlConnection connection)
        {
            var DeleteQuery = "DELETE [Category] WHERE [Id]=@id";
            var rows = connection.Execute(DeleteQuery, new
            {
                id = new Guid("85058569-27fe-4aef-991d-45461ce0038d")
            });

            Console.WriteLine($"{rows} registros apagados");
        }
    }
}
