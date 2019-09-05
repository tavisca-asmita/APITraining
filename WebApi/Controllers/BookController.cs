using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly BookService BookService;
        public BookController()
        {
            BookService = new BookService();
        }

        // GET: api/Book
        [HttpGet]
        public List<Book> Get()
        {
            return BookService.Get();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return BookService.Get(id);
        }

        // POST: api/Book
        [HttpPost]
        public List<Book> Post([FromBody] Book book)
        {
            return BookService.Post(book);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public List<Book> Put(int id, [FromBody] string name)
        {
            return BookService.Put(id, name);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Book> Delete(int id)
        {
            return BookService.Delete(id);
        }
    }
}
