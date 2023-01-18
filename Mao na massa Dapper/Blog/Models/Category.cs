using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Mao_na_massa_Dapper.Blog.Models
{
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string slug { get; set; }

        // public List<Post> Posts { get; set; }
    }
}
