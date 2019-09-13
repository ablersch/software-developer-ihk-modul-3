using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL
{
    class Program
    {
        // Connection String um festzulegen zu welchem Server und zu welcher Datenbank eine verebindung aufgebaut werden soll
        static string connectionString = @"Data Source=PC-DOZ-602\SQLEXPRESS; Initial Catalog=SoftwareDeveloper; User Id=softwaredeveloper; Password = 123test;";
        // lokale SQL Datenbank
        //static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Medien;";

        static void Main(string[] args)
        {
            WriteSqlData();
            ReadSqlData();
            UpdateSqlData(2, "1234 Seiten");
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
                string sql = "SELECT * FROM Medien";

                // DataSet
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                sqlDataAdapter.Fill(dataSet, "Medien");

                // Um geänderte Daten im DataSet zu aktualisieren
                // da.Update(ds);

                DataTable dataTable = dataSet.Tables["Medien"];


                // Alle Zeilen durchlaufen
                foreach (DataRow dr in dataTable.Rows)
                {
                    Console.Write(dr[0].ToString() + " ");
                    Console.Write(dr[1].ToString() + " ");
                    Console.Write(dr[2].ToString() + " ");
                    Console.Write(dr[3].ToString() + " ");
                    Console.Write(dr[4].ToString());
                    Console.WriteLine("");
                }

                // Alternative
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader.GetInt32(0)} Titel: {reader.GetString(1)} Eigenschaft: {reader.GetString(4)}");
                        }
                    }
                }
            }
        }

        static void WriteSqlData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO Buecher ([Signatur],[Titel], Eigenschaft, Typ, Leihstatus) VALUES('12345', 'C#', '333 Seiten', 'Buch', 0 )";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Wieviel Zeilen wurden hinzugefügt
                        int rows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Fehler loggen und Fehlermeldung ausgeben
            }
        }

        static void UpdateSqlData(int id, string value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Das Feld Author ändern bei dem Datensatz mit der angegebenen ID
                    var sql = $"UPDATE Medien SET Eigenschaft = '{value}' WHERE Id =  {id}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Wieviel Zeilen wurden hinzugefügt
                        int rows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Fehler loggen und Fehlermeldung ausgeben
            }
        }
    }
}
