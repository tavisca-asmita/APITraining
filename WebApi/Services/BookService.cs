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

        public int Delete(int id)
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

        public List<Book> Get()
        {
            return BookList;
        }

        public Book Get(int id)
        {
            if (id <= 0)
                return null;
            else
            {
                foreach (var item in BookList)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public int Post(Book book)
        {
            bool flag = true;
            if (book.Id <= 0 || book.Price <= 0)
                return -1;
            else if (book.Name.Contains('0') || book.Name.Contains('1') ||
                    book.Name.Contains('2') || book.Name.Contains('3') ||
                    book.Name.Contains('4') || book.Name.Contains('5') ||
                    book.Name.Contains('6') || book.Name.Contains('7') ||
                    book.Name.Contains('8') || book.Name.Contains('9'))
                return -1;
            else if (book.Author.Contains('0') || book.Author.Contains('1') ||
                    book.Author.Contains('2') || book.Author.Contains('3') ||
                    book.Author.Contains('4') || book.Author.Contains('5') ||
                    book.Author.Contains('6') || book.Author.Contains('7') ||
                    book.Author.Contains('8') || book.Author.Contains('9'))
                return -1;
            else if (book.Category.Contains('0') || book.Category.Contains('1') ||
                    book.Category.Contains('2') || book.Category.Contains('3') ||
                    book.Category.Contains('4') || book.Category.Contains('5') ||
                    book.Category.Contains('6') || book.Category.Contains('7') ||
                    book.Category.Contains('8') || book.Category.Contains('9'))
                return -1;

            if (flag)
            {
                foreach(var item in BookList)
                {
                    if (item.Id == book.Id)
                        return 0;
                }
                BookList.Add(book);                
            }
            return 1;
        }         

        public int Put(int id, Book book)
        {
            if (id <= 0)
                return -1;
            else
            {
                foreach (var item in BookList)
                {
                    if (item.Id == id)
                    {
                        item.Name = book.Name;
                        item.Author = book.Author;
                        item.Category = book.Category;
                        item.Price = book.Price;
                        return 1;
                    }
                }
            }            
            return 0;
        }
    }
}
