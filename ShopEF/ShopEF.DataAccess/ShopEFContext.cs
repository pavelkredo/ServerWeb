using System.Data.Entity;
using ShopEF.DataAccess.Models;

namespace ShopEF.DataAccess
{
    public class ShopEFContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopEFContext() : base("ShopEFDatabase")
        {
            Database.SetInitializer(new ShopEFContextInitializer());
        }
    }
}
