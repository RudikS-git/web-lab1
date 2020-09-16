using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using testweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace testweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Models.Type> foods { get; set; }
        public List<Models.Product> products { get; set; }

        public IndexModel(ApplicationContext db)
        {
            _context = db;

            ApplicationContext.SeedProduct(_context);
        }

        public void OnGet()
        {
            foods = _context.foods.Include(type => type.products).AsNoTracking().ToList();
            products = _context.products.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.products.FindAsync(id);

            if(product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteTypeAsync(int id)
        {
            var type = await _context.foods.FindAsync(id);

            if (type != null)
            {
                _context.foods.Remove(type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
