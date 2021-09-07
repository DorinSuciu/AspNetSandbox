using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksServiceTests
    {

        [Fact]
        public void BooksServicePostTest()
        {
            //Asume
            var booksService = new BooksService();

            // Act
            booksService.Post(new Book
            {
                Title = "Test Book Nr1",
                Author = "Tester 1 ",
                Language = "test 1"
            });
            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "Test Book Nr2",
                Author = "Tester 2",
                Language = "test 2"
            });


            // Assert
            Assert.Equal("Test Book Nr1", booksService.Get(3).Title);
        }

        [Fact]
        public void BooksServicePutTest()
        {
            //Asume
            var booksService = new BooksService();

            // Act
            booksService.Put(1, new Book
            {
                Id = 1,
                Title = "Test Book Nr1",
                Author = "Tester 1 ",
                Language = "test 1"
            }) ;
            //booksService.Delete(2);
            //booksService.Post(new Book
            //{
            //    Title = "Test Book Nr2",
            //    Author = "Tester 2",
            //    Language = "test 2"
            //});


            // Assert
            Assert.Equal("Test Book Nr1", booksService.Get(1).Title);
        }
    }
}
