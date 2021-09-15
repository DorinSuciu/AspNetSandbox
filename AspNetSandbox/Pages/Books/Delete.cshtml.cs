﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext _context;
        private readonly IHubContext<MessageHub> hubContext;

        public DeleteModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            _context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FindAsync(id);

            if (Book != null)
            {
                _context.Book.Remove(Book);
                await hubContext.Clients.All.SendAsync("DeletedBook", Book);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
