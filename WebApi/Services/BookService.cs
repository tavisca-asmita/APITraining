﻿using System;
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
        private static List<Book> BookList;
        private readonly BookData BookData;
        public BookService()
        {            
            BookData = new BookData();
            BookList = BookData.GetBookList();
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
                return null;
            }            
        }

        public int Post(Book book)
        {
            if (book.Id <= 0 || book.Price <= 0 || !Regex.IsMatch(book.Name, @"^[a-zA-Z# ]+$") || !Regex.IsMatch(book.Author, @"^[a-zA-Z# ]+$") || !Regex.IsMatch(book.Category, @"^[a-zA-Z# ]+$"))
                return -1;
            
            else
            {
                foreach(var item in BookList)
                {
                    if (item.Id == book.Id)
                        return 0;
                }
                BookList.Add(book);
                return 1;
            }
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
                return 0;
            } 
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
    }
}
