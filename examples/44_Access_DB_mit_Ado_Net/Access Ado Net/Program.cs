using System;
using System.Data.OleDb;

namespace Access_Ado_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            // The connection string assumes that the Access .
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from Medien;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
