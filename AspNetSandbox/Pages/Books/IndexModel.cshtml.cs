using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext _context;

        public IndexModel(AspNetSandbox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
