using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox.Data;
using AspNetSandbox.Models;

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
        private readonly IBookRepository repository;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<BooksController>

        /// <summary>Gets all the books.</summary>
        /// <returns>list of book objects.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(repository.GetBooks());
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = repository.GetBooks(id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        // POST api/<BooksController>

        /// <summary>Adds the specified book in the Book list.</summary>
        /// <param name="book">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5

        /// <summary>Replace the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Book book)
        {
               repository.ReplaceBook(id, book);
               return Ok();
        }

        // DELETE api/<BooksController>/5

        /// <summary>Deletes the specified bok by id.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
    }
}
