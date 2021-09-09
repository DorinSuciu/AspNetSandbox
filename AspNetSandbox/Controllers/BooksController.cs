using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandbox.Controllers
{
    /// <summary>
    /// Controller that allows us to get books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>

        /// <summary>Gets all the books.</summary>
        /// <returns>list of book objects.</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.GetBooks();
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.GetBooks(id));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        // POST api/<BooksController>

        /// <summary>Adds the specified book in the Book list.</summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            booksService.AddBook(value);
        }

        // PUT api/<BooksController>/5

        /// <summary>Replace the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The book value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            booksService.ReplaceBook(id, value);
        }

        // DELETE api/<BooksController>/5

        /// <summary>Deletes the specified bok by id.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.DeleteBook(id);
        }
    }
}
