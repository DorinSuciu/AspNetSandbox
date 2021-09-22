using System.Collections.Generic;
using AspNetSandbox.DTOs;
using AspNetSandbox.Models;

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