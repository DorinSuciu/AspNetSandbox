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

        /// <summary>Gets all the books.</summary>
        /// <returns>list of book objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetBooks());
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = repository.GetBookById(id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        /// <summary>Adds the specified book in the Book list.</summary>
        /// <param name="book">The value.</param>
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
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

        /// <summary>Replace the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book value.</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
               repository.ReplaceBook(id, book);
               return Ok();
        }

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
