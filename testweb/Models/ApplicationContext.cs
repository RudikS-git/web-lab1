using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testweb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Type> Types { get; set; }
        public DbSet<Product> products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static void SeedProduct(ApplicationContext context)
        {
            Random random = new Random();

            if (!context.Types.Any())
            {
                List<Type> list = new List<Type>()
                {
                    new Type()
                    {
                        Name = "Продовольственные",

                        Children = new List<Type>()
                        {
                            new Type
                            {
                                Name = "Кисломолочные",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Творог",
                                        NameCompany = "Простоквашино",
                                        Price = random.Next(55, 200),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Кефир",
                                        NameCompany = "Село Зелёное",
                                        Price = random.Next(55, 200),

                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Сметана",
                                        NameCompany = "Простоквашино",
                                        Price = random.Next(55, 200),
                                    },
                                },

                                Children = new List<Type>()
                                {
                                    new Type()
                                    {
                                        Name = "Йогурты",
                                        Products = new List<Product>()
                                        {
                                            new Product()
                                            {
                                                Amount = random.Next(0, 50000),
                                                Name = "Йогурт Растишка",
                                                NameCompany = "DANONE",
                                                Price = random.Next(55, 200),

                                            }
                                        },

                                    }
                                }
                            
                            },
                        
                            new Type()
                            {
                                Name = "Мясные",

                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Курица",
                                        NameCompany = "Глазовская птица",
                                        Price = random.Next(150, 300),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Говядина",
                                        NameCompany = "Мираторг",
                                        Price = random.Next(150, 300),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Свинина",
                                        NameCompany = "Дальние Дали",
                                        Price = random.Next(150, 300),
                                    },
                                },
                            },

                            new Type()
                            {
                                Name = "Хлебобулочные",

                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Хлеб",
                                        NameCompany = "Ароматный",
                                        Price = random.Next(15, 50),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Батон",
                                        NameCompany = "Семейные традиции",
                                        Price = random.Next(15, 50),
                                    },
                                },

                                
                            },

                            new Type()
                            {
                                Name = "Рыбные",

                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Селдь",
                                        NameCompany = "Смоленская Коллекция",
                                        Price = random.Next(15, 50),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 50000),
                                        Name = "Селдь",
                                        NameCompany = "Русская рыба",
                                        Price = random.Next(15, 50),
                                    }
                                },
                            },
                        },

                        
                    },

                    new Type()
                    {
                        Name = "Непродовольственные",

                        Children = new List <Type>()
                        {
                            new Type()
                            {
                                Name = "Одеждо-обувные",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 500),
                                        Name = "Куртка",
                                        NameCompany = "Adidas",
                                        Price = random.Next(12000, 15000),

                                    },
                                    new Product()
                                    {
                                        Amount = random.Next(0, 500),
                                        Name = "Футболка",
                                        NameCompany = "Levi's",
                                        Price = random.Next(1000, 2000),
                                    },

                                },

                            },

                            new Type()
                            {
                                Name = "Электротовары",

                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 1000),
                                        Name = "Холодильник RTM 16",
                                        NameCompany = "INDESIT",
                                        Price = random.Next(20000, 25000),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 1000),
                                        Name = "Посудомоечная машина M6C7PD",
                                        NameCompany = "DEXP",
                                        Price = random.Next(12000, 15000),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 1000),
                                        Name = "Стиральная машина CS41051D1/2-07",
                                        NameCompany = "Candy",
                                        Price = random.Next(150, 300),
                                    },
                                },

                            },

                            new Type()
                            {
                                Name = "Хозяйственные",

                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Amount = random.Next(0, 1000),
                                        Name = "Bath Fungri",
                                        NameCompany = "Prosept",
                                        Price = random.Next(100, 300),
                                    },

                                    new Product()
                                    {
                                        Amount = random.Next(0, 1000),
                                        Name = "Dos-clean",
                                        NameCompany = "Grass",
                                        Price = random.Next(200, 400),
                                    },
                                },

                            },
                        }
                    }

                    
                };

                context.Types.AddRange(list);
                context.SaveChanges();
            }


        }
    }
}
