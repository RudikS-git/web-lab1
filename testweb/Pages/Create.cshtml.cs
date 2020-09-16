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
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        
        [BindProperty]
        public Models.Product Product { get; set; }
        public List<Models.Type> foods { get; set; }
        public CategoriesProduct Categories { get; set; }

        public CreateModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(CategoriesProduct categories)
        {
            foods = _context.foods.Include(type => type.products).AsNoTracking().ToList();
            Categories = categories;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
               // Product.TypeId = (int)Categories;
                _context.products.Add(Product);
                
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}