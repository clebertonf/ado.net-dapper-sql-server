using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao_na_massa_Dapper.Blog.Models
{
    [Table("[User]")]
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string slug { get; set; }

        [Write(false)] // Não inclui na hora de inserir no banco
        public List<Role> Roles { get; set; }
    }
}
