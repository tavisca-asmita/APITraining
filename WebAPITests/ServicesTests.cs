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
            string bookName = BookService.Get(1);
            Assert.Equal("C#", bookName);
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
            int booksCount = BookList.Count;
            List<Book> bookList = BookService.Post(book);
            Assert.Equal(booksCount + 1, bookList.Count);
        }
    }
}
