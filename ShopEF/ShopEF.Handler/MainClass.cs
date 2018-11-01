using System;
using System.Data.Entity;
using System.Linq;
using ShopEF.DataAccess;
using ShopEF.DataAccess.Models;

namespace ShopEF.Handler
{
    internal class MainClass
    {
        private static void Main()
        {
            using (var shopDatabase = new ShopEFContext())
            {
                // Поиск таких товаров, которые имеют категорию "Одежда"
                var products = shopDatabase.Products.AsNoTracking().Where(p => p.Categories.Any(c => c.Name.Equals("Одежда")));

                Console.WriteLine("Товары с категорией \"Одежда\":");
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine();

                // Изменить категорию с названием "Джинсы"
                var categoryChanged = shopDatabase.Categories.AsNoTracking().FirstOrDefault(c => c.Name.Equals("Джинсы"));
                if (categoryChanged != null)
                {
                    categoryChanged.Name = "Штаны";
                }

                // Удалить заказ, где Id = 2
                var orderDeleted = new Order { Id = 2 };
                shopDatabase.Entry(orderDeleted).State = EntityState.Deleted;

                // Поиск самого часто покупаемого товара
                var productHit = shopDatabase.Products.AsNoTracking().OrderByDescending(p => p.Orders.Count).First();
                Console.WriteLine("Самый часто покупаемый товар: " + productHit.Name);
                Console.WriteLine();

                // Поиск количества потраченных денег клиентом
                var customersSpendMoneyCount = shopDatabase.Orders.AsNoTracking().GroupBy(o => o.Customer).Select(c => new
                {
                    Name = c.Key.FullName,
                    Count = c.SelectMany(o => o.Products).Sum(p => p.Cost)
                }).ToList();

                Console.WriteLine("Количество потраченных денег каждым клиентом:");
                foreach (var customerSpendMoneyCount in customersSpendMoneyCount)
                {
                    Console.WriteLine(customerSpendMoneyCount.Name + " " + customerSpendMoneyCount.Count);
                }
                Console.WriteLine();

                // Поиск количества купленных товаров для каждой категории
                var categoriesProductsSelled = shopDatabase.Orders.AsNoTracking()
                    .SelectMany(o => o.Products)
                    .SelectMany(p => p.Categories)
                    .GroupBy(c => c.Name)
                    .Select(s => new
                    {
                        Name = s.Key,
                        Count = (double)s.Count()
                    });

                Console.WriteLine("Количество купленных товаров для каждой категории:");
                foreach (var categoryProductsSelled in categoriesProductsSelled)
                {
                    Console.WriteLine(categoryProductsSelled.Name + " " + categoryProductsSelled.Count);
                }
            }
        }
    }
}