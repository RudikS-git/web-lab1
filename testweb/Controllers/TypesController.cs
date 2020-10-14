using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testweb.Models;

namespace testweb.Controllers
{
    [Route("[controller]/[action]")]
    public class TypesController : Controller
    {
        private ApplicationContext _context;
        public TypesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var type = _context.Types.Include(e => e.Products).ToList().Find(it => it.Id == id);

            if (type != null)
            {
                _context.Types.Remove(type);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        /*[HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var type = _context.Types.Include(e => e.Products).ToList().Find(it => it.Id == id);

            if (type.Parent != null)
            {
                var newParent = _context.Types.First(it => it.Id == type.Parent.Id);

                if (newParent.Products == null)
                {
                    newParent.Products = new List<Product>();
                }

                newParent.Products.AddRange(type.Products);

                List<Models.Product> products = _context.products.ToList().FindAll(it => it.Head?.Id == type.Id);

                if (products != null)
                {
                    foreach (var item in products)
                    {
                        item.Head = newParent;
                        _context.Attach(item).State = EntityState.Modified;
                    }
                }

                newParent.Children.Remove(type);
                _context.Attach(newParent).State = EntityState.Modified;

                if (type.Children != null)
                {
                    foreach (var item in type.Children)
                    {
                        item.Parent = newParent;
                        _context.Attach(item).State = EntityState.Modified;
                    }
                }

            }
            else
            {
                if (type.Children != null)
                {
                    type.Children.ForEach(it =>
                    {
                        it.Parent = null;
                        _context.Attach(it).State = EntityState.Modified;
                    });
                }
            }


            if (type != null)
            {
                _context.Types.Remove(type);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
*/
    }
}
