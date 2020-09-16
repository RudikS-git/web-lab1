using System;

namespace testweb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string NameCompany { get; set; }
        public string Name { get; set; }

        public int TypeId { get; set; }

    }
}
