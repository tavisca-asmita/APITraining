using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class BookData
    {
        public static List<Book> BookList;

        public BookData()
        {
            BookList = new List<Book>
            {
                new Book { Name = "C", Id = 1, Price = 50, Author = "C# Author", Category = "Programming Language" },
                new Book { Name = "F", Id = 2, Price = 80, Author = "F# Author", Category = "Programming Language" }
            };
        }

        public List<Book> GetBookList()
        {
            return BookList;
        }
    }
}
