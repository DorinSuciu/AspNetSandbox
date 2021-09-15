using AspNetSandbox.DTOs;
using AspNetSandbox.Models;
using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBookRepository
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetBooks();

        Book GetBookById(int id);

        void AddBook(Book value);

        void ReplaceBook(int id, Book value);
    }
}