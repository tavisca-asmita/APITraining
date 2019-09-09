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
        private readonly BookData BookData;
        public BookService()
        {            
            BookData = new BookData();
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

        public List<string> Post(Book book)
        {
            List<string> errors = new List<string>();
            bool validateName = Regex.IsMatch(book.Name, @"^[a-zA-Z# ]+$");
            bool validateAuthor = Regex.IsMatch(book.Author, @"^[a-zA-Z# ]+$");
            bool validateCategory = Regex.IsMatch(book.Category, @"^[a-zA-Z# ]+$");

            if(book.Id <= 0 || book.Price <= 0 || !validateName || !validateAuthor || !validateCategory)
            {
                if (book.Id <= 0)
                    errors.Add("Id Must Not Be Negative");
                if (book.Price <= 0)
                    errors.Add("Price Must Be Positive");
                if (!validateName)
                    errors.Add("Name Must Not Contain Digits");
                if (!validateAuthor)
                    errors.Add("Author Must Not Contain Digits");
                if (!validateCategory)
                    errors.Add("Category Must Not Contain Digits");
            }
            
            else
            {
                int status = BookData.CheckIfBookExists(book);
                if (status == 0)
                {
                    errors = null;
                    errors.Add("Present");
                }
                else
                {
                    errors = null;
                    errors.Add("Added");
                }
                    
            }
            return errors;
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
