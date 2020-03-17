using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2B_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                var db = new DB();
                db.Select(connection);
                db.Delete(connection, 11);
                db.Insert(connection, 11, "Bielsko");
                db.Insert(connection, 202, "d-test");
                db.Delete(connection, 201);
                connection.Close();
            }


            Console.ReadKey();
        }
    }
}
