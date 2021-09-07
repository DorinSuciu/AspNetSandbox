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
        public void ConvertResponseToWeatherForecastTest()
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
    }
}
