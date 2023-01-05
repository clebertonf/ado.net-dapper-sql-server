using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace EstudoDapper.Models
{
    internal class CareerItem
    {
        public Guid Id{ get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
}
