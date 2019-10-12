using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Uebung_SQL
{
    class Program
    {
        // Connection String für die Verbindung zur Datenbank
        static string connectionString = @"Data Source=PC-DOZ-602\SQLEXPRESS; Initial Catalog=SoftwareDeveloper; User Id=softwaredeveloper; Password = 123test;";

        static void Main(string[] args)
        {
            Console.WriteLine("Daten von Datenbank lesen? (r)");
            Console.WriteLine("Daten in die Datenbank schreiben? (w)");

            string input = Console.ReadLine();

            if (input == "r" || input == "w")
            {
                if (input == "r")
                {
                    Console.WriteLine("Welches Geschlecht? männlich oder weiblich?");
                    foreach (var item in ReadData(Console.ReadLine()))
                    {
                        Console.Write($"Nachname: {item.Nachname} ");
                        Console.Write($"Vorname: {item.Vorname} ");
                        Console.Write($"Geschlecht: {item.Geschlecht} ");
                        Console.Write($"Login: {item.Login} ");
                        Console.Write($"Alter: {item.Alter} ");
                        Console.WriteLine();
                    }
                }

                if (input == "w")
                {
                    Benutzer benutzer = new Benutzer();
                    Console.WriteLine("Daten schreiben. ID wird automatisch erzeugt");
                    Console.WriteLine("Nachname:");
                    benutzer.Nachname = Console.ReadLine();

                    Console.WriteLine("Vorname:");
                    benutzer.Vorname = Console.ReadLine();

                    // TODO Prüfen auf gültiges Geschlecht
                    Console.WriteLine("Geschlecht:");
                    benutzer.Geschlecht = Console.ReadLine();

                    Console.WriteLine("Login:");
                    benutzer.Login = Console.ReadLine();

                    Console.WriteLine("Alter:");

                    Int32.TryParse(Console.ReadLine(), out int alter);
                    benutzer.Alter = alter;

                    WriteData(benutzer);
                }
            }
            else
            {
                Console.WriteLine("Falsche Menüeingabe.");
            }

            Console.WriteLine("Taste drücken um das Programm zu beenden");
            Console.ReadLine();
        }

        /// <summary>
        /// Daten von Datenbank lesen
        /// </summary>
        /// <param name="geschlecht">Als Filter wird das Geschlecht genutzt</param>
        /// <returns>Liste von Benutzerdaten</returns>
        static List<Benutzer> ReadData(string geschlecht)
        {
            var resultList = new List<Benutzer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT Nachname, Vorname, Geschlecht, Login, [Alter] FROM Benutzer WHERE Geschlecht= '{geschlecht}'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Benutzer benutzer = null;
                        while (reader.Read())
                        {
                            benutzer = new Benutzer();
                            benutzer.Nachname = reader.GetString(0);
                            benutzer.Vorname = reader.GetString(1);   
                            if (!reader.IsDBNull(2)) benutzer.Geschlecht = reader.GetString(2);
                            benutzer.Login = reader.GetString(3);
                            if (!reader.IsDBNull(4)) benutzer.Alter = reader.GetInt32(4);
                            resultList.Add(benutzer);
                        }
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// Daten in die SQL Datenbank schreiben
        /// </summary>
        /// <param name="benutzer">Das Objekt welches in die Datenbank geschrieben werden soll</param>
        static void WriteData(Benutzer benutzer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = $"INSERT INTO Benutzer(Nachname, Vorname, Geschlecht, Login, [Alter]) " +
                             $"VALUES('{benutzer.Nachname}', '{benutzer.Vorname}', '{benutzer.Geschlecht.ToString()}', '{benutzer.Login}', {benutzer.Alter})";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rows = command.ExecuteNonQuery();
                        if (rows != 0) Console.WriteLine("Datensatz erfolgreich geschrieben.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Fehler beim Datensatz schreiben: " + ex.Message);
            }
        }
    }
}


