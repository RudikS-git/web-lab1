using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testweb.Models;

namespace testweb.Pages
{
    public class EditTypeModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Models.Type Type { get; set; }
        public List<Models.Type> Types { get; set; }
        [BindProperty]
        public Nullable<int> Id { get; set; }

        public EditTypeModel(ApplicationContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Types = _context.Types.Include(type => type.Products).Include(type => type.Parent).AsNoTracking().ToList();
            if (id == null)
            {
                return NotFound();
            }

            Type = Types.Find(it => it.Id == id);

            if (Type == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Type.Parent = new Models.Type();
          /*  if(Id == null)
            {
                //var parent = _context.Types.ToList().Find(it => it.Id == Type.Id).Parent;

                //parent.Children.Remove(Type.);
                Type.Parent.Children.Remove(Type);
                _context.Attach(Type.Parent).State = EntityState.Modified;
                Type.Parent.Id = null;
            }
            else
            {
                Type.Parent.Id = Id;
            }*/

            if(Id == null)
            {
                var parent = _context.Types.ToList().Find(it => it.Children.FirstOrDefault(e => e.Id == Type.Id) != null);
                parent.Children.Remove(parent.Children.Where(it => it.Id == Type.Id).First<Models.Type>());
                Type.Parent = null;
             //   _context.Attach(parent).State = EntityState.Modified;
            }
            else
            {
                Type.Parent.Id = Id;
            }

            _context.Attach(Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.products.Any(e => e.Id == Type.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
    }
}