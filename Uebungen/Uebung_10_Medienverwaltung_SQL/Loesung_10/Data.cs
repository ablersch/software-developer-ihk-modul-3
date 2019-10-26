using System;
using System.Collections;
using System.Data.SqlClient;

namespace Medienauswahl_Aufgabe_3
{
    static class Data
    {
        static string connectionString = @"Data Source=PC-DOZ-602\SQLEXPRESS; Initial Catalog=SoftwareDeveloper; User Id=softwaredeveloper; Password = 123test;";

        /// <summary>
        /// Daten speichern
        /// </summary>
        /// <param name="key">ID des Elements</param>
        /// <param name="data">Das zu speichernde Datenobjekt</param>
        internal static void AddData(int key, Medien data)
        {
            string tempEigenschaft = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Medien VALUES(@Sig,@Titel,@Eigenschaft,@Typ,@Leihstatus)", connection))
                    {
                        if (data is Buecher)
                        {
                            Buecher buch;
                            buch = data as Buecher;
                            tempEigenschaft = buch.Seitenzahl.ToString();
                        }
                        else if (data is Videos)
                        {
                            Videos video;
                            video = data as Videos;
                            tempEigenschaft = video.Laufzeit.ToString();
                        }

                        command.Parameters.AddWithValue("@Sig", data.Signatur);
                        command.Parameters.AddWithValue("@Titel", data.Titel);
                        command.Parameters.AddWithValue("@Eigenschaft", tempEigenschaft);
                        command.Parameters.AddWithValue("@Typ", data.Typ.ToString());
                        command.Parameters.AddWithValue("@Leihstatus", data.Leihstatus.ToString());

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Fehler beim Datensatz schreiben: " + ex.Message);
            }
        }

        /// <summary>
        /// Prüfen ob die ID/Key eindeutig ist
        /// </summary>
        /// <param name="key">Zu prüfende ID</param>
        /// <returns>true = id erlaubt  ;  false = id nicht erlaubt</returns>
        internal static bool IsKeyEindeutig(int key)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT count(1) FROM Medien WHERE Signatur = '" + key + "'", connection))
                    {
                        result = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO
            }

            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Gibt alle Elemente zurück
        /// </summary>
        /// <returns>Eine ArrayList das alle Elemente beinhaltet</returns>
        internal static ArrayList GetAllElements()
        {
            ArrayList arrayList = new ArrayList();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Medien", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Enum.TryParse(reader.GetString(3), out Medien.TypBezeichnung typ);
                                Enum.TryParse(reader.GetString(4), out Medien.LeihstatusBezeichnung leihstatus);

                                if (reader.GetString(3) == Medien.TypBezeichnung.Video.ToString())
                                {
                                    Videos video = new Videos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), typ, leihstatus);
                                    arrayList.Add(video);
                                }
                                else if (typ == Medien.TypBezeichnung.Buch)
                                {
                                    Buecher buch = new Buecher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), typ, leihstatus);
                                    arrayList.Add(buch);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO
            }

            return arrayList;
        }

        /// <summary>
        /// Holt ein Element
        /// </summary>
        /// <param name="key">ID/Key des Elements</param>
        /// <returns>Wurde das Element gefunden wird das Object zurückgegebene, ansonsten null</returns>
        internal static Medien GetElement(int key)
        {
            Medien tempObject = null;

            if (!IsKeyEindeutig(key))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM Medien WHERE Signatur='" + key + "'", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Enum.TryParse(reader.GetString(3), out Medien.TypBezeichnung typ);
                                    Enum.TryParse(reader.GetString(4), out Medien.LeihstatusBezeichnung leihstatus);

                                    if (typ == Medien.TypBezeichnung.Video)
                                    {
                                        Videos video = new Videos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), typ, leihstatus);
                                        tempObject = video;
                                    }
                                    else if (typ == Medien.TypBezeichnung.Buch)
                                    {
                                        Buecher buch = new Buecher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), typ, leihstatus);
                                        tempObject = buch;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // TODO
                }

                return tempObject;
            }
            else
            {
                Console.WriteLine("Signatur nicht gefunden!");
                return null;
            }
        }

        /// <summary>
        /// Löscht ein Element   
        /// </summary>
        /// <param name="key">ID/Key des Elements</param>
        internal static void DeleteElement(int key)
        {
            if (!IsKeyEindeutig(key))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("DELETE Medien WHERE Signatur = '" + key + "'", connection))
                        {
                            command.ExecuteNonQuery();

                            Console.WriteLine("Medium mit der Signatur: " + key + " erfolgreich gelöscht.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Fehler beim löschen vonm Medium mit der Signatur: " + key + ".");
                }
            }    
        }

        /// <summary>
        /// Ändert den Leihstatus eines Eintrages in der DB
        /// </summary>
        /// <param name="key"></param>
        /// <param name="leihstatus"></param>
        internal static void ChangeElementLeihstatus(int key, Medien.LeihstatusBezeichnung leihstatus)
        {
            if (!IsKeyEindeutig(key))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("UPDATE Medien SET Leihstatus ='" + leihstatus.ToString() + "' WHERE Signatur='" + key + "'", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // TODO
                }
            }
        }
    }
}

