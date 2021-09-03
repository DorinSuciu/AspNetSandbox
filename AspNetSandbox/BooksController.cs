using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private Book[] books;

        public BooksController()
        {
            books = new Book[2];
            books[0] = new Book();
            books[0].Id = 1;
            books[0].Title = "Sapiens - o scurta istorie a omenirii";
            books[0].Author = "Yuval Noah Harari";
            books[0].Language = "Romanian";

            books[1] = new Book();
            books[1].Id = 2;
            books[1].Title = "Deep Work";
            books[1].Author = "Cal Newport";
            books[1].Language = "English";
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
