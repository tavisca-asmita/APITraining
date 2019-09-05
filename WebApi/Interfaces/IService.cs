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
        string Get(int id);
        //Book Put(int id, double price);
        List<Book> Put(int id, string name);
        List<Book> Post(Book book);
        //List<Book> Post(double price);
        List<Book> Delete(int id);
    }
}
