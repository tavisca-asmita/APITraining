using System.Collections.Generic;
using FluentValidation.Results;
using WebApi.Model;
using WebApi.Interfaces;
using WebApi.Data;
using WebApi.Validation;

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
            var validator = new IdValidator();
            ValidationResult validationResult = validator.Validate(id);
            bool success = validationResult.IsValid;
            if (!success)
                return null;
            else
            {
                List<Book> bookList = BookData.GetBookList();
                foreach (var item in bookList)
                {
                    if (item.Id == id)
                        return item;
                }
                return null;
            }            
        }

        public List<string> Post(Book book)
        {
            List<string> results = new List<string>();
            var validator = new BookValidator();
            ValidationResult validationResult = validator.Validate(book);
            bool success = validationResult.IsValid;
            
            if (!success)
            {
                IList<ValidationFailure> validationFailures = validationResult.Errors;
                foreach (var error in validationFailures)
                {
                    results.Add(error.ToString());
                }
                return results;
            }
            else
            {
                int status = BookData.CheckIfBookExists(book);
                if (status == 0)
                    results.Add("Present");
                else
                    results.Add("Added");
                return results;
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
                List<Book> bookList = BookData.GetBookList();
                foreach (var item in bookList)
                {
                    if (item.Id == id)
                    {
                        int index = bookList.IndexOf(item);
                        BookData.UpdateBook(index, book);
                        return 1;
                    }
                }
                BookData.AddBook(book);
                return 1;                
            } 
        }

        public int Delete(int id)
        {
            List<Book> bookList = BookData.GetBookList();
            foreach (var item in bookList)
            {
                if (item.Id == id)
                {
                    BookData.DeleteBook(item);
                    return 1;
                }
            }
            return 0;
        }
    }
}
