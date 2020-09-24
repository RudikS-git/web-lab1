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
        public List<Models.Type> tree { get; set; }
        public List<Models.Product> products { get; set; }

        public IndexModel(ApplicationContext db)
        {
            _context = db;

            ApplicationContext.SeedProduct(_context);
        }

        public void OnGet()
        {
            var list = _context.Types.Include(e => e.Children).ThenInclude(e => e.Products).Include(e => e.Parent).Include(e => e.Products).Where(it => it.Parent == null).AsNoTracking().ToList();
            tree = new List<Models.Type>();

            Sort(list, 0);

            products = _context.products.Include(e => e.Head).AsNoTracking().ToList();

            foreach(var item in tree)
            {
                if(item.Products == null)
                {
                    item.Products = products.FindAll(it => it.Head.Id == item.Id).ToList();
                    
                }
            }

            SetCount(tree);
        }

        public void Sort(List<Models.Type> types, int position)
        {
            foreach (var item in types)
            {
                if(tree.Find(it => it.Id == item.Id) != null)
                {
                    continue;
                }

                if(item != null)
                {
                    item.Position = position;
                    position++;

                    tree.Add(item);

                    if(item.Children == null)
                    {
                        item.Children = _context.Types.ToList().FindAll(it => it.Parent?.Id == item.Id);
                    }


                    Sort(item.Children, position);
                    position--;

                }
            }
        }

        public int SetCount(List<Models.Type> types)
        {
            int count = 0;
            int sum = 0;

            foreach (var item in types)
            {
                if(item.Children != null)
                {
                    count += SetCount(item.Children);
                }
                
                if(item.Products != null)
                {
                    count += item.Products.Count;
                }

                count++;
                sum += count;
                item.Count = count;
                count = 0;
            }

            return sum;
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
            var type = await _context.Types.FindAsync(id);

            if (type != null)
            {
                _context.Types.Remove(type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
