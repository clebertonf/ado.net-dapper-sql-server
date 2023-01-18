using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao_na_massa_Dapper.Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // public int categoryId { get; set; }
    }
}
