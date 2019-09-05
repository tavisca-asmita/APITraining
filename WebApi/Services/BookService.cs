using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Interfaces;
using WebApi.Data;

namespace WebApi.Services
{
    public class BookService : IService
    {
        private readonly List<Book> BookList;
        private readonly BookData BookData;
        public BookService()
        {            
            BookData = new BookData();
            BookList = BookData.GetBookList();
        }

        public List<Book> Delete(int id)
        {
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    BookList.Remove(item);
                    break;
                }

            }
            return BookList;
        }

        public List<Book> Get()
        {
            return BookList;
        }

        public string Get(int id)
        {
            string s = "";
            if (id <= 0)
                s = "Invalid Id, Id should be a positive number.";
            else
            {
                foreach (var item in BookList)
                {
                    if (item.Id == id)
                    {
                        s = item.Name;
                        break;
                    }
                    else
                    {
                        s = "Book Not Found";
                    }
                }
            }                    
            return s;
        }

        public List<Book> Post(Book book)
        {
            bool flag = true;
            if (book.Id <= 0 || book.Price <= 0)
                flag = false;
            else if (book.Name.Contains('0') || book.Name.Contains('1') ||
                    book.Name.Contains('2') || book.Name.Contains('3') ||
                    book.Name.Contains('4') || book.Name.Contains('5') ||
                    book.Name.Contains('6') || book.Name.Contains('7') ||
                    book.Name.Contains('8') || book.Name.Contains('9'))
                flag = false;
            else if (book.Author.Contains('0') || book.Author.Contains('1') ||
                    book.Author.Contains('2') || book.Author.Contains('3') ||
                    book.Author.Contains('4') || book.Author.Contains('5') ||
                    book.Author.Contains('6') || book.Author.Contains('7') ||
                    book.Author.Contains('8') || book.Author.Contains('9'))
                flag = false;
            else if (book.Category.Contains('0') || book.Category.Contains('1') ||
                    book.Category.Contains('2') || book.Category.Contains('3') ||
                    book.Category.Contains('4') || book.Category.Contains('5') ||
                    book.Category.Contains('6') || book.Category.Contains('7') ||
                    book.Category.Contains('8') || book.Category.Contains('9'))
                flag = false;

            if (flag)
            {
                BookList.Add(book);
                return BookList;
            }

            else
                return BookList;
        }         

        public List<Book> Put(int id, string name)
        {
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    item.Name = name;
                    break;
                }
            }
            return BookList;
        }
    }
}
