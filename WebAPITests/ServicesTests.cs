using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebApi;
using WebApi.Services;
using WebApi.Model;
using WebApi.Data;
using System.Linq;

namespace WebAPITests
{
    public class ServicesTests
    {
        public List<Book> BookList;
        public BookData BookData;
        public BookService BookService;
        public ServicesTests()
        {
            BookData = new BookData();
            BookList = BookData.GetBookList();
            BookService = new BookService();
        }

        [Fact]
        public void GetTest()
        {
            List<Book> bookList = BookService.Get();
            bool isSame = BookList.Count == bookList.Count ? true : false;
            if (isSame)
            {
                BookList.ForEach(Book => isSame = isSame && bookList.Any(book => book.Id == Book.Id && book.Name == Book.Name));
            }
            Assert.True(isSame);  
        }

        [Fact]
        public void GetByIdTest()
        {
            Book book = BookService.Get(1);
            Book expectedBook = new Book
            {
                Name = "C#",
                Id = 1,
                Price = 50,
                Author = "C# Author",
                Category = "Programming Language"
            };
            Assert.Equal(expectedBook, BookService.Get(1));
        }

        [Fact]
        public void PostTest()
        {
            Book book = new Book
            {
                Id = 3,
                Name = "Java",
                Author = "George",
                Category = "Programming",
                Price = 100
            };
            int status = BookService.Post(book);
            Assert.Equal(1, status);
        }
    }
}
