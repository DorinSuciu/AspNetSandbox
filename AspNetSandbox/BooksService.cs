using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Sapiens - o scurta istorie a omenirii",
                Author = "Yuval Noah Harari",
                Language = "Romanian"
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "Deep Work",
                Author = "Cal Newport",
                Language = "English"
            });
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {

            return books.Single(book => book.Id == id);

        }

        public void Post(Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }
        public void Put(int id, string value)
        {

        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}

