using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2B_Lab_2
{
    public class DB
    {
        //lista klientów
        public void Select(SqlConnection connection)
        {
            var query = "SELECT * FROM Customers"; 
            var command = new SqlCommand(query, connection); 

            var reader = command.ExecuteReader(); 
            reader.Read(); 

            while (reader.Read())
            {
                
                Console.WriteLine(reader["CompanyName"]);
            }
            reader.Close(); 
        }

        //wstawianie danych do tabeli Region
        public void Insert(SqlConnection connection, int id, string description)
        {
            var query = "INSERT INTO Region(RegionID, RegionDescription)" +
                "VALUES (@id, @description)";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} row affected");
        }

        //usuwanie danych z taneli Region
        public void Delete(SqlConnection connection, int id)
        {
            var query = "DELETE FROM Region WHERE RegionID = @id";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            var deleted = command.ExecuteNonQuery();
            Console.WriteLine($"{deleted} row deleted");

        }

        //aktualizacja danych w tabeli Region
        public void Update(SqlConnection connection, int id, string description)
        {
            var query = "UPDATE Region SET RegionDescription = @description" + "WHERE RegionID = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);

            var update = command.ExecuteNonQuery();
            Console.WriteLine($"{update} row updated");

        }
    }
}
