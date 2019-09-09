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
        public ActionResult<List<Book>> Get()
        {
            List<Book> bookList = BookService.Get();
            if (bookList == null)
                return NoContent();
            return Ok(bookList);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<Book>> Get(int id)
        {
            Book book = BookService.Get(id);
            if (book != null)
                return Ok(book);
            return NoContent();
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<List<string>> Post([FromBody] Book book)
        {
            List<string> errors = new List<string>();
            errors = BookService.Post(book);
            foreach(var error in errors)
            {
                if (error.Contains("Must"))
                {
                    return BadRequest(errors);
                }
            }                             
                return Ok(errors);                     
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Book book)
        {
            int status = BookService.Put(id, book);
            if (status == -1)
            {
                return BadRequest("ID can not be negative");
            }
            if (status == 0)
            {
                return NoContent();
            }
            return id + " Updated";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            int status = BookService.Delete(id);
            if (status == 0)
            {
                return NoContent();
            }
            return id + " Deleted";
        }
    }
}
