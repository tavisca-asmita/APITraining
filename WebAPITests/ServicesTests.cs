using System;
using System.Collections.Generic;
using Xunit;
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
            Assert.Equal(expectedBook.Id, book.Id);
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

        [Fact]
        public void NegativeIdPostTest()
        {
            Book book = new Book
            {
                Id = -3,
                Name = "Java",
                Author = "George",
                Category = "Programming",
                Price = 100
            };
            Assert.Equal(-1, BookService.Post(book));
        }

        [Fact]
        public void StringWithNumberPostTest()
        {
            Book book = new Book
            {
                Id = 3,
                Name = "Jav1a",
                Author = "George",
                Category = "Programming",
                Price = 100
            };
            Assert.Equal(-1, BookService.Post(book));
        }

        [Fact]
        public void AlreadyPresentPostTest()
        {
            Book book = new Book { Name = "C#", Id = 1, Price = 50, Author = "C# Author", Category = "Programming Language" };
            Assert.Equal(0, BookService.Post(book));
        }

        [Fact]
        public void PutTest()
        {
            Book book = new Book { Name = "C#", Id = 1, Price = 60, Author = "C# Author", Category = "Programming Language" };
            Assert.Equal(1, BookService.Put(1, book));
        }

        [Fact]
        public void NegativeIdPutTest()
        {
            Book book = new Book { Name = "C#", Id = -1, Price = 60, Author = "C# Author", Category = "Programming Language" };
            Assert.Equal(-1, BookService.Put(-1, book));
        }

        [Fact]
        public void NoContentPutTest()
        {
            Book book = new Book { Name = "C#", Id = 1, Price = 60, Author = "C# Author", Category = "Programming Language" };
            Assert.Equal(0, BookService.Put(6, book));
        }

        [Fact]
        public void DeleteTest()
        {
            Assert.Equal(1, BookService.Delete(1));
        }

        [Fact]
        public void IdNotPresentDeleteTest()
        {
            Assert.Equal(0, BookService.Delete(8));
        }
    }
}
