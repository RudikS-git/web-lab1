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

            if (Id != null)
            {
                Type.Parent.Id = Id;

                Models.Type type = _context.Types.Include(e => e.Children).Include(e => e.Parent).AsNoTracking().ToList().Find(it => it.Id == Type.Id);
                if (type.Parent == null)
                {
                    foreach (var item in type.Children)
                    {
                        _context.Database.ExecuteSqlRaw("UPDATE Types SET ParentId = NULL WHERE Id = {0}", item.Id);
                    }

                    _context.Database.ExecuteSqlRaw("UPDATE Types SET ParentId = {0} WHERE Id = {1}", Id, Type.Id);
                    return RedirectToPage("Index");
                }
            }
            else Type.Parent.Id = 1;

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

            if (Id == null)
            {
                /*var parent = _context.Types.ToList().Find(it => it.Children.FirstOrDefault(e => e.Id == Type.Id) != null);
                parent.Children.Remove(parent.Children.Where(it => it.Id == Type.Id).First<Models.Type>());
                Type.Parent = null;*/
                //   _context.Attach(parent).State = EntityState.Modified;

                _context.Database.ExecuteSqlRaw("UPDATE Types SET ParentId = NULL WHERE Id = {0}", Type.Id);
                // return RedirectToPage("Index");
            }

            return RedirectToPage("Index");
        }
    }
}