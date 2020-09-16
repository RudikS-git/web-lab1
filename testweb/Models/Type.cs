using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testweb.Models
{
    public class Type
    {
        public enum CategoriesProduct
        {
            Food = 0,
            NonFood = 1
        }

        public int Id { get; set; }
        public string Name{ get; set; }
        public CategoriesProduct Categories { get; set; }

        public List<Product> products { get; set; }
    }
}
