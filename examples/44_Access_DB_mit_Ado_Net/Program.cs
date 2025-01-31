using System.Data.OleDb;

namespace Access_mit_Ado_Net;

internal class Program
{
    private static void Main(string[] args)
    {
        // ConnectionString zur Access DB.
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb";

        // Query erstellen um alle Elemente aus der Tabelle Medien zu erhalten..
        string queryString = "SELECT * from Medien;";

        using OleDbConnection connection = new OleDbConnection(connectionString);

        OleDbCommand command = new OleDbCommand(queryString, connection);

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