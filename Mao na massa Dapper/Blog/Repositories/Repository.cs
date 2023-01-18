using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class Repository<T> where T : class // Só onde T seja uma classe, caso contrario não é aceito
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
          =>  _connection = connection;

        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }
    }
}
