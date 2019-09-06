using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Interfaces;
using WebApi.Data;

namespace WebApi.Services
{
    public class BookService : IService
    {
        //private static List<Book> BookList;
        private readonly BookData BookData;
        public BookService()
        {            
            BookData = new BookData();
            //BookList = BookData.GetBookList();
        }
                
        public List<Book> Get()
        {
            return BookData.GetBookList();
        }

        public Book Get(int id)
        {
            if (id <= 0)
                return null;
            else
            {
                return BookData.GetBookById(id);
            }            
        }

        public int Post(Book book)
        {
            bool validateName = Regex.IsMatch(book.Name, @"^[a-zA-Z# ]+$");
            bool validateAuthor = Regex.IsMatch(book.Author, @"^[a-zA-Z# ]+$");
            bool validateCategory = Regex.IsMatch(book.Category, @"^[a-zA-Z# ]+$");

            if (book.Id <= 0 || book.Price <= 0 || !validateName || !validateAuthor || !validateCategory)
                return -1;
            
            else
            {
                return BookData.AddBook(book);
            }
        }         

        public int Put(int id, Book book)
        {
            if (id <= 0)
                return -1;
            else
            {
                if (book.Equals(null))
                    return 0;
                return BookData.UpdateBook(id, book);
            } 
        }

        public int Delete(int id)
        {
            return BookData.DeleteBook(id);
        }
    }
}
