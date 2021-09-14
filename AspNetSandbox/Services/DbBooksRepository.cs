using AspNetSandbox.Data;
using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Book.ToList();
        }

        public Book GetBookById(int id)
        {
            var book = context.Book
               .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void ReplaceBook(int id, Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }
    }
}
