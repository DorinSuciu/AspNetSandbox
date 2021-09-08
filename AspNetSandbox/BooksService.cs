using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private static int id;
        private List<Book> books;

        public BooksService()
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

        public Book GetBooks(int id)
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
                books[id-1] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBooks(id));
        }
    }
}

