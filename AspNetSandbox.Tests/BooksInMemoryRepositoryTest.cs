using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using AspNetSandbox.Services;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// This is test suite for BooksController.
    /// </summary>
    public class BooksInMemoryRepositoryTest
    {
        private BooksInMemoryRepository booksService;

        /// <summary>
        /// Bookses the service add book test.
        /// </summary>
        [Fact]
        public void BooksServiceAddBookTest()
        {
            // Asume
            BooksInMemoryRepository.ResetId();
            booksService = new BooksInMemoryRepository();

            // Act
            booksService.AddBook(new Book
            {
                Title = "Test Book Nr1",
                Author = "Tester 1",
                Language = "test 1",
            });
            booksService.DeleteBook(2);
            booksService.AddBook(new Book
            {
                Title = "Test Book Nr2",
                Author = "Tester 2",
                Language = "test 2",
            });

            // Assert
            Assert.Equal("Test Book Nr1", booksService.GetBookById(3).Title);
            Assert.Equal("Tester 1", booksService.GetBookById(3).Author);
            Assert.Equal("test 1", booksService.GetBookById(3).Language);
        }

        /// <summary>
        /// Bookses the service replace book test.
        /// </summary>
        [Fact]
        public void BooksServiceReplaceBookTest()
        {
            // Asume
            BooksInMemoryRepository.ResetId();
            booksService = new BooksInMemoryRepository();

            // Act
            booksService.ReplaceBook(1, new Book
            {
                Id = 1,
                Title = "Test Book Nr3",
                Author = "Tester 3",
                Language = "test 3",
            });

            // Assert
            Assert.Equal("Test Book Nr3", booksService.GetBookById(1).Title);
            Assert.Equal("Tester 3", booksService.GetBookById(1).Author);
            Assert.Equal("test 3", booksService.GetBookById(1).Language);
        }
    }
}
