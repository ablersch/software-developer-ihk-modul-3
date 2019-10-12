using System;
using System.Collections.Generic;
using System.Linq;

namespace Uebung_SQL_Entity_Framework
{
    class Program
    {
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
                    OutputData(GetBenutzer(Console.ReadLine()));
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

                    CreateBenutzer(benutzer);
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
        /// Daten ausgeben
        /// </summary>
        /// <param name="dataList">List aller Benutzer</param>
        static void OutputData(List<Benutzer> dataList)
        {
            foreach (var benutzer in dataList)
            {
                Console.Write($"Nachname: {benutzer.Nachname} ");
                Console.Write($"Vorname: {benutzer.Vorname} ");
                Console.Write($"Geschlecht: {benutzer.Geschlecht} ");
                Console.Write($"Login: {benutzer.Login} ");
                Console.Write($"Alter: {benutzer.Alter} ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Alle Einträge von Benutzer zurückgeben
        /// </summary>
        /// <returns></returns>
        static List<Benutzer> GetBenutzer(string geschlecht)
        {
            using (SoftwareDeveloperEntities context = new SoftwareDeveloperEntities())
            {
                List<Benutzer> benutzerList = context.Benutzer.Where(s => s.Geschlecht.StartsWith(geschlecht)).ToList();
                return benutzerList;
            }
        }

        /// <summary>
        /// Neuen Benutzer anlegen
        /// </summary>
        /// <returns>Gibt den angelegten Benutzer zurück</returns>
        static void CreateBenutzer(Benutzer benutzer)
        {
            using (SoftwareDeveloperEntities context = new SoftwareDeveloperEntities())
            {
                benutzer.Id = Guid.NewGuid();
                context.Benutzer.Add(benutzer);
                context.SaveChanges();
            }
        }
    }
}
