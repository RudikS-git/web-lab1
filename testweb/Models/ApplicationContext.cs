using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testweb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Type> foods { get; set; }
        public DbSet<Product> products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static void SeedProduct(ApplicationContext context)
        {
            Random random = new Random();

            if (!context.foods.Any())
            {
                List<Type> list = new List<Type>()
                {
                    new Type()
                    {
                        Name = "Кисломолочные",
                        products = new List<Product>()
                        {
                            new Product()
                            {
                                Amount = random.Next(0, 50000),
                                Name = "Йогурт Растишка",
                                NameCompany = "DANONE",
                                Price = random.Next(55, 200),

                            },
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

                        Categories = Type.CategoriesProduct.Food


                    },

                    new Type()
                    {
                        Name = "Мясные",

                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.Food
                    },

                    new Type()
                    {
                        Name = "Хлебобулочные",

                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.Food
                    },

                    new Type()
                    {
                        Name = "Рыбные",

                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.Food
                    },

                    new Type()
                    {
                        Name = "Одеждо-обувные",
                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.NonFood

                    },

                    new Type()
                    {
                        Name = "Электротовары",

                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.NonFood
                    },

                    new Type()
                    {
                        Name = "Хозяйственные",

                        products = new List<Product>()
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

                        Categories = Type.CategoriesProduct.NonFood
                    },
                };

                context.foods.AddRange(list);
                context.SaveChanges();
            }


        }
    }
}
