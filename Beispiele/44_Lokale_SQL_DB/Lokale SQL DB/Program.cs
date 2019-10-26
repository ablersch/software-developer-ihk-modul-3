using System;
using System.Data.SqlClient;

namespace Lokale_SQL_DB
{
    class Program
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LokaleDb;";

        static void Main(string[] args)
        {
            ReadSqlData();
            Console.ReadLine();
        }

        static void ReadSqlData()
        {
            // Bereich in welchem das Objekt "connection" gültig ist. Danach wird es automatisch verworfen!
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL QUery um alle Dtaen der Tabelle "Test" abzurufen
                string sql = "SELECT * FROM [Table]";

                // Alternative
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader.GetInt32(0)}");
                        }
                    }
                }
            }
        }
    }
}
