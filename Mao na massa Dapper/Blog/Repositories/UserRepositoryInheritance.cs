using Dapper;
using Mao_na_massa_Dapper.Blog.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Mao_na_massa_Dapper.Blog.Repositories
{
    public class UserRepositoryInheritance : Repository<User> // Herda repositorio generico, passando o Tipo usuario (temos todos metodos crud disponiveis)
    {
        private readonly SqlConnection _connection;

        public UserRepositoryInheritance(SqlConnection connection) : base (connection) // base, chamando contrutor da classe base
          => _connection = connection;

        public List<User> ReadUsersWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if(role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
    }
}