using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public List<Models.Type> tree { get; set; }

        [BindProperty]
        public int? IdParent { get; set; }


        public CreateModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(int id)
        {
            tree = _context.Types.Include(type => type.Products).AsNoTracking().ToList();
            IdParent = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                Product.Head = _context.Types.ToList().Find(it => it.Id == Product.Head.Id);
                _context.products.Add(Product);
                
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}