using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using Newtonsoft.Json.Linq;

namespace WebApi.Data
{
    public class BookData
    {
        public static List<Book> BookList;

        public BookData()
        {
            BookList = new List<Book>
            {
                new Book { Name = "C#", Id = 1, Price = 50, Author = "C# Author", Category = "Programming Language" },
                new Book { Name = "F#", Id = 2, Price = 80, Author = "F# Author", Category = "Programming Language" }
            };
        }

        public List<Book> GetBookList()
        {
            return BookList;
        }

        public Book GetBookById(int id)
        {
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public int AddBook(Book book)
        {            
            foreach (var item in BookList)
            {
                if (item.Id == book.Id)
                    return 0;
            }
            BookList.Add(book);
            return 1;
        }

        public int UpdateBook(int id, Book book)
        {
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    item.Id = book.Id;
                    item.Name = book.Name;
                    item.Price = book.Price;
                    item.Author = book.Author;
                    item.Category = book.Category;
                    return 1;
                }
            }
            return 0;
        }

        public int DeleteBook(int id)
        {
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    BookList.Remove(item);
                    return 1;
                }                
            }
            return 0;            
        }

    }
}
