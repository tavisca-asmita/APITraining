using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Interfaces
{
    interface IService
    {
        List<Book> Get();
        Book Get(int id);
        //Book Put(int id, double price);
        int Put(int id, Book book);
        List<string> Post(Book book);
        //List<Book> Post(double price);
        int Delete(int id);
    }
}
