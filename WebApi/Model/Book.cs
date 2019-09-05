using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Book
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }                     
    }
}
