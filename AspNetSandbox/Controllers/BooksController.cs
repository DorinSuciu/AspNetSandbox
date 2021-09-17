using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.SignalR;
using AspNetSandbox.DTOs;
using AutoMapper;

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
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        /// <summary>Gets all the books.</summary>
        /// <returns>list of book objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var bookList = repository.GetBooks();
            var bookDtoList = mapper.Map<IEnumerable<ReadBookDto>>(bookList);
            return Ok(bookDtoList);
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ReadBookDto object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = repository.GetBookById(id);
                ReadBookDto bookDto = mapper.Map<ReadBookDto>(book);
                return Ok(bookDto);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        /// <summary>Adds the specified book in the Book list.</summary>
        /// <param name="bookDto">The value.</param>
        [HttpPost]
        public IActionResult Post([FromBody]CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBook(book);
                hubContext.Clients.All.SendAsync("CreatedBook", book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>Replace the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookDto">The book value.</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.ReplaceBook(id, book);
            hubContext.Clients.All.SendAsync("UpdatedBook", book);
            return Ok();
        }

        /// <summary>Deletes the specified bok by id.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           repository.DeleteBook(id);
           hubContext.Clients.All.SendAsync("DeletedBook", id);
           return Ok();
        }
    }
}
