using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transaction
{
    internal class Transaction
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ShopDatabase"].ConnectionString;

        private static void Main()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var transaction = connection.BeginTransaction();

                try
                {
                    const string sqlQuery = "INSERT INTO Categories (Name) VALUES ('Периферия');";

                    var command = new SqlCommand(sqlQuery, connection) { Transaction = transaction };
                    command.ExecuteNonQuery();

                    throw new Exception();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
