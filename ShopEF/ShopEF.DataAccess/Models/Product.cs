using System.Collections.Generic;

namespace ShopEF.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
