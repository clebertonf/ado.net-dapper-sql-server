using EstudoDapper.Métodos_Base;
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
                MetodosBaseDapper.ListCategories(connection);
                // MetodosBaseDapper.InsertCategorie(connection);
            }
        }
    }
}