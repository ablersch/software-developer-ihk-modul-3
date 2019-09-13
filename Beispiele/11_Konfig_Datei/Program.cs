using System;
using System.Configuration;

namespace Konfig_Datei
{
    class Program
    {
        static void Main(string[] args)
        {

            string key1 = ConfigurationManager.AppSettings["Key1"];
            Console.WriteLine("Key1: " + key1);

            string connection = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            Console.WriteLine("DBConnect: " + connection);



            // Zur Laufzeit ist keine permanente Änderung an der app.config möglich da wenn die Anwendung
            // verteilt wird der Inhalt der app.config in Application.exe.config im Programmverzeichniss kopiert wird.
            // Zur Laufzeit kann deshalb nur die Application.exe.config modifiziert werden

            // Die App.config der Anwendung öffnen  
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // neuen Wert in die Application Setting einfügen   
            config.AppSettings.Settings.Add("AktuellesDatum", DateTime.Now.ToShortDateString());
            // die Änderungen speichern (NUR temporär)   
            config.Save(ConfigurationSaveMode.Modified);

            // Den geänderten Bereich neu laden
            ConfigurationManager.RefreshSection("appSettings");

            ShowConfig();

            Console.WriteLine("\nTaste drücken um zu beenden...");
            Console.ReadKey();
        }


        static void ShowConfig()
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                Console.WriteLine("Key: {0}, Value: {1}", key, value);
            }
        }
    }
}
