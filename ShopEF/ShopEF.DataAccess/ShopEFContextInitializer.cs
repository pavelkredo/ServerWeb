using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEF.DataAccess.Models;

namespace ShopEF.DataAccess
{
    class ShopEFContextInitializer : DropCreateDatabaseAlways<ShopEFContext>
    {
        protected override void Seed(ShopEFContext shopDatabase)
        {
            // Инициализация категорий
            var categories = new List<Category>
            {
                new Category { Name = "Одежда" },
                new Category { Name = "Джинсы" },
                new Category { Name = "Куртки" },
                new Category { Name = "Аксессуары" },
                new Category { Name = "Часы" }
            };
            shopDatabase.Categories.AddRange(categories);

            // Инициализация покупателей
            var customers = new List<Customer>
            {
                new Customer {FullName = "Петр Владимирович Иванов", Phone = "+7 913 545-32-23", Email = "ivanovpv@mail.ru"},
                new Customer {FullName = "Владислав Борисович Карелин", Phone = "+7 952 442-76-24", Email = "vladislavkarelin@yandex.ru"}
            };
            shopDatabase.Customers.AddRange(customers);

            shopDatabase.SaveChanges();

            // Инициализация товаров
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Levi's skinny jeans", Cost = 8900,
                    Categories = shopDatabase.Categories.Where(c => c.Name.Equals("Одежда") || c.Name.Equals("Джинсы")).ToList()
                },
                new Product
                {
                    Name = "Zara black jacket", Cost = 6200,
                    Categories = shopDatabase.Categories.Where(c => c.Name.Equals("Одежда") || c.Name.Equals("Куртки")).ToList()
                },
                new Product
                {
                    Name = "Casio G-Shock", Cost = 9500,
                    Categories = shopDatabase.Categories.Where(c => c.Name.Equals("Аксессуары") || c.Name.Equals("Часы")).ToList()
                },
            };
            shopDatabase.Products.AddRange(products);

            shopDatabase.SaveChanges();

            // Инициализация заказов
            var orders = new List<Order>
            {
                new Order
                {
                    Date = DateTime.Now, CustomerId = 1,
                    Products = shopDatabase.Products
                        .Where(p => p.Name.Equals("Levi's skinny jeans") || p.Name.Equals("Casio G-Shock")).ToList()
                },
                new Order
                {
                    Date = DateTime.Now, CustomerId = 2,
                    Products = shopDatabase.Products.Where(p => p.Name.Equals("Zara black jacket") || p.Name.Equals("Levi's skinny jeans")).ToList()
                }
            };
            shopDatabase.Orders.AddRange(orders);

            shopDatabase.SaveChanges();
        }
    }
}