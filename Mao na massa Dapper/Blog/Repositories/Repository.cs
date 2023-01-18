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

        public T Get(int id)
        {
            return _connection.Get<T>(id);
        }

        public void Create(T model)
        {
            _connection.Insert<T>(model);
        }

        public void Update(T model)
        {
           _connection.Update<T>(model);
        }

        public void Delete(T model)
        {
           _connection.Delete<T>(model);
        }

        // Nome igual Delete (método tem uma sobrecarga)
        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}
