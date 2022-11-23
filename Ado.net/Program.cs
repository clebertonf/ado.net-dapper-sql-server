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
                connection.Open();
                System.Console.WriteLine("Successfully connected to the database");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [title] FROM [Course]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        System.Console.WriteLine(reader.GetString(0));
                    }
                };
            }
        }
    }
}