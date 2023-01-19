using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class UserRepositoryInheritance : Repository<User> // Herda repositorio generico, passando o Tipo usuario (temos todos metodos crud disponiveis)
    {
        private readonly SqlConnection _connection;

        public UserRepositoryInheritance(SqlConnection connection) : base (connection) // base, chamando contrutor da classe base
          => _connection = connection;
    }
}
