using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetSandbox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there!");
                }
                else
                {
                    var book = new Book();
                    book.Id = 1;
                    book.Title = "Wuthering Heights";
                    book.Author = "Emily Bronte";
                    book.Language = "English";
                    applicationDbContext.Add(book);
                    var book2 = new Book();
                    book.Id = 2;
                    book2.Title = "Moby Dick";
                    book2.Author = "Herman Melville";
                    book2.Language = "English";
                    applicationDbContext.Add(book2);

                    // applicationDbContext.SaveChanges();
                    Book book3 = new ()
                    {
                        Id = 3,
                        Title = "Arta manipularii",
                        Author = "Kevin Dutton",
                        Language = "Romanian",
                    };
                    applicationDbContext.Add(book3);
                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}
