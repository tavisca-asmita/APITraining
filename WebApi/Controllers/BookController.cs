using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ValuesController));

        public readonly BookService BookService;
        public BookController()
        {
            BookService = new BookService();
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            log.Info("Get() Book");
            List<Book> bookList = BookService.Get();
            if (bookList == null)
                return NoContent();
            return Ok(bookList);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<Book>> Get(int id)
        {
            log.Info("Get(id) Book");
            if (id > 0)
            {
                Book book = BookService.Get(id);
                if (book != null)
                    return Ok(book);
                return NoContent();
            }
            else
                return BadRequest("Id Must Be Positive");
            
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<List<string>> Post([FromBody] Book book)
        {
            List<string> results = new List<string>();
            results = BookService.Post(book);            
            if (results[0].Contains("Must"))
                return BadRequest(results);
            else
                return Ok(results);                     
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
