using System;
using Serilog;

namespace Medienverwaltung_Aufgabe_9;

internal class Program
{
    private static void CreateLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
    }

    private static void Main()
    {
        CreateLogger();

        Medium tempMedium;
        string auswahl = string.Empty;

        Console.WriteLine("Medienverwaltung");

        while (auswahl != "q")
        {
            Console.WriteLine("\n#### Menue ####");
            Console.WriteLine("Anlegen eines neuen Buch 'b'");
            Console.WriteLine("Anlegen eines neuen Video 'v'");
            Console.WriteLine("Anlegen eines neuen Tonie 't'");
            Console.WriteLine("Ausgabe der vorhandenen Medien 'a'");
            Console.WriteLine("Entleihen des Medium 'e Signatur'");
            Console.WriteLine("Rueckgabe des Medium 'r Signatur'");
            Console.WriteLine("Löschen des Medium 'l Signatur'");
            Console.WriteLine("Programm beenden 'q'\n");

            auswahl = Console.ReadLine();
            int signatur = 0;
            if (auswahl.Length > 5 && auswahl.Contains(' '))
            {
                string[] temp = auswahl.Split(' ');
                auswahl = temp[0];
                if (!int.TryParse(temp[1], out signatur))
                {
                    Log.Information("Keine gültige Signatur eingegeben");
                    continue;
                }
            }

            Console.WriteLine();
            switch (auswahl)
            {
                case "b":
                    var buch = new Buch();
                    buch.DatenEingeben();
                    Data.AddElement(buch);
                    break;

                case "v":
                    var video = new Video();
                    video.DatenEingeben();
                    Data.AddElement(video);
                    break;

                case "t":
                    var tonie = new Tonie();
                    tonie.DatenEingeben();
                    Data.AddElement(tonie);
                    break;

                case "a":
                    var allMedien = Data.GetAllElements();
                    if (allMedien.Count > 0)
                    {
                        Medium.AusgabeUeberschrift();
                    }
                    foreach (var medium in allMedien)
                    {
                        medium.Ausgabe();
                    }
                    break;

                case "e":
                    tempMedium = Data.GetElement(signatur);
                    tempMedium?.Entleihen();
                    break;

                case "r":
                    tempMedium = Data.GetElement(signatur);
                    tempMedium?.Rueckgabe();
                    break;

                case "l":
                    Data.DeleteElement(signatur);
                    break;

                case "q":
                    break;

                default:
                    Log.Information("Falsche Menüeingabe.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}