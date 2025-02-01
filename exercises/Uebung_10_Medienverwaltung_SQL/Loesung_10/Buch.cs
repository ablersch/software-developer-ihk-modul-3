using System;
using Serilog;

namespace Medienverwaltung_Aufgabe_9;

internal class Buch : Medium
{
    public int Seitenzahl { get; set; }

    public override void DatenEingeben()
    {
        base.DatenEingeben();

        do
        {
            Console.WriteLine("Seitenzahl eingeben:");
            if (!int.TryParse(Console.ReadLine(), out int seitenzahl))
            {
                Log.Logger.Warning("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben.");
            }
            else
            {
                Seitenzahl = seitenzahl;
            }
        }
        while (Seitenzahl == 0);
    }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Seitenzahl {4,-15}", Signatur, nameof(Buch), KurzerTitel(), Status, Seitenzahl);
    }
}