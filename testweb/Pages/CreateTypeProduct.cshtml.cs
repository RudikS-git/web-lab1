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
        public List<Models.Type> tree { get; set; }

        public CreateTypeProductModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(int categories)
        {
            tree = _context.Types.Include(type => type.Products).AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if(Type.Parent.Id == -1)
                {
                    Type.Parent = null;
                }
                else
                {
                    Type.Parent = _context.Types.ToList().Find(it => it.Id == Type.Parent.Id);
                }

                _context.Types.Add(Type);

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
