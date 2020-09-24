using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testweb.Models
{
    public class Type
    {
       /*public Type()
        {
            Children = new List<Type>();
            Products = new List<Product>();
        }*/

        public int Id { get; set; }
        public string Name{ get; set; }

        public Type Parent { get; set; }
        
        public List<Type> Children { get; set; }
        public List<Product> Products { get; set; }

        [NotMapped]
        public int Position { get; set; }

        [NotMapped]
        public int Count { get; set; }
    }
}
