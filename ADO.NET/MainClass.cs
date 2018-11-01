using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class MainClass
    {
        private static void Main()
        {
            Console.WriteLine("Общее число товаров: " + DatabaseHandler.GetProductsCount());

            var productsList = DatabaseHandler.GetProductsList();
            foreach (var product in productsList)
            {
                Console.WriteLine(product);
            }

            var productsData = DatabaseHandler.GetProductsDataSet().Tables[0].Rows;
            foreach (DataRow product in productsData)
            {
                Console.WriteLine(product[0] + " - " + product[1]);
            }
        }
    }
}
