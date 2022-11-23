using Dapper;
using EstudoDapper.Models;
using Microsoft.Data.SqlClient;
using System;

namespace EstudoDapper.Métodos_Base
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

        }
    }
}
