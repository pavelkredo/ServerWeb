using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    public static class DatabaseHandler
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ShopDatabase"].ConnectionString;

        private static readonly SqlConnection databaseConnection = new SqlConnection(connectionString);

        public static int GetProductsCount()
        {
            int productsCount;

            OpenConnection();

            var sqlQuery = "SELECT COUNT(*) FROM PRODUCTS";

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                productsCount = (int)command.ExecuteScalar();
            }

            CloseConnection();

            return productsCount;
        }

        public static void CategoryCreate(string categoryName)
        {
            OpenConnection();

            var sqlQuery = "INSERT INTO Categories (Name) VALUES ('" + categoryName + "');";

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public static void ProductCreate(string productName, int categoryId)
        {
            OpenConnection();

            var sqlQuery = "INSERT INTO Products (Name, CategoryId) VALUES ('"
                           + productName + "', " + categoryId + ");";

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public static void ProductChangeName(int productId, string productNameNew)
        {
            OpenConnection();

            var sqlQuery = "UPDATE Products SET Name = '" + productNameNew + "' WHERE Id = " + productId;

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public static void ProductDelete(int productId)
        {
            OpenConnection();

            var sqlQuery = "DELETE Products WHERE Id = " + productId;

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public static List<string> GetProductsList()
        {
            OpenConnection();

            var sqlQuery = "SELECT Products.Name, Categories.Name FROM Products " +
                           "LEFT JOIN Categories ON Products.CategoryId = Categories.Id";

            var productsList = new List<string>();

            using (var command = new SqlCommand(sqlQuery, databaseConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productsList.Add(reader[0] + " - " + reader[1]);
                    }
                }
            }

            CloseConnection();

            return productsList;
        }

        public static DataSet GetProductsDataSet()
        {
            OpenConnection();

            var sqlQuery = "SELECT Products.Name, Categories.Name FROM Products " +
                           "LEFT JOIN Categories ON Products.CategoryId = Categories.Id";

            var productsDataSet = new DataSet();

            using (var adapter = new SqlDataAdapter(sqlQuery, databaseConnection))
            {
                adapter.Fill(productsDataSet);
            }

            return productsDataSet;
        }

        private static void OpenConnection()
        {
            databaseConnection.Open();
        }

        private static void CloseConnection()
        {
            databaseConnection?.Close();
        }
    }
}