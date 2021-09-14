using AspNetSandbox.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetSandbox.Services
{
    public class BooksInMemoryRepository : IBookRepository
    {
        private static int id;
        private List<Book> books;

        public BooksInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Sapiens - o scurta istorie a omenirii",
                Author = "Yuval Noah Harari",
                Language = "Romanian",
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "Deep Work",
                Author = "Cal Newport",
                Language = "English",
            });
        }

        public static void ResetId()
        {
            id = 0;
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Single(_ => _.Id == id);
        }

        public void AddBook(Book value)
        {
            int previousId = books[books.Count - 1].Id;
            value.Id = previousId + 1;
            books.Add(value);
        }

        public void ReplaceBook(int id, Book value)
        {
            if (id == value.Id)
            {
                books[id - 1] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBookById(id));
        }
    }
}