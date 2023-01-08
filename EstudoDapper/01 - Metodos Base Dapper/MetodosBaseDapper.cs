using Dapper;
using EstudoDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EstudoDapper.Metodos_Base
{
    public static class MetodosBaseDapper
    {
        // Metodos base

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

        public static void InsertManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var categoryTwo = new Category();
            categoryTwo.Id = Guid.NewGuid();
            categoryTwo.Title = "NodeJS/JavaScript";
            categoryTwo.Url = "node";
            categoryTwo.Description = "Categoria destinada a cursos de nodeJS";
            categoryTwo.Order = 9;
            categoryTwo.Summary = "Node JS";
            categoryTwo.Featured = false;

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
            var rows = connection.Execute(insertSql, new[]
            {
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new 
                {
                    categoryTwo.Id,
                    categoryTwo.Title,
                    categoryTwo.Url,
                    categoryTwo.Summary,
                    categoryTwo.Order,
                    categoryTwo.Description,
                    categoryTwo.Featured
                }
            });

            Console.WriteLine(rows);
        }

        // Executando Procedures

        // Sem retorno
        public static void ExecuteProcedureDeleteStudent(SqlConnection connection)
        {
            var procedure = "spDeleteStudent";
            var parameters = new { StudentId = "79b82071-80a8-4e78-a79c-92c8cd1fd052" };
            var affectedRows = connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linhas afetadas");
        }

        // Com retorno (Tipo Dynamic)
        public static void ExecuteProcedureReadCoursesByCategoryID(SqlConnection connection)
        {
            var procedure = "spGetCoursesByCategory";
            var parameters = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(procedure, parameters, commandType: CommandType.StoredProcedure);

            foreach (var item in courses)
            {
                Console.WriteLine(item.Title);
            }
        }

        public static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                [Category]
             OUTPUT inserted.[Id]
             VALUES(
                  NEWID(),
                  @Title,
                  @Url,
                  @Summary,
                  @Order,
                  @Description,
                  @Featured)";

            // Insert retorna o id inserido no banco
            var GuidId = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{GuidId} da categoria inserida.");
        }

        public static void ExecuteViews(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }

        }

        // Relacionamentos

        public static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(sql,
                (CareerItem, Course) =>
                {
                    CareerItem.Course = Course;
                    return CareerItem;
                }, splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine($"Carreira => {item.Title} - Curso: {item.Course.Title}");
            }
        }

        public static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                SELECT 
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM 
                    [Career] 
                INNER JOIN 
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY
                    [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql, (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else
                    {
                        car.Items.Add(item);
                    }

                    return career;
                }, splitOn: "CareerId");

             foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        public static void QueryMutiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine(item.Title);
                }

                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        public static void SelectIn(SqlConnection connection)
        {
            var query = @"select * from Career where [Id] IN @Id";

            var items = connection.Query<Career>(query, new
            {
                Id = new[]{
                    "4327ac7e-963b-4893-9f31-9a3b28a4e72b",
                    "e6730d1c-6870-4df3-ae68-438624e04c72"
                }
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }

        }

        public static void Like(SqlConnection connection)
        {
            var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @exp";
            var term = "%api%";

            var items = connection.Query<Course>(query, new
            {
                exp = $"%{term}%"
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }

        public static void Transaction(SqlConnection connection)
        {

        }
    }
}
