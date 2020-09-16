using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testweb.Models;
using static testweb.Models.Type;

namespace testweb.Pages
{
    public class CreateTypeProductModel : PageModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public Models.Type Type { get; set; }
        public List<Models.Type> foods { get; set; }

        public CreateTypeProductModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(CategoriesProduct categories)
        {
            foods = _context.foods.Include(type => type.products).AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.foods.Add(Type);

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
