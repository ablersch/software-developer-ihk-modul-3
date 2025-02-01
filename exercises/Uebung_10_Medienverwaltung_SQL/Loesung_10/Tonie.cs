using System;

namespace Medienverwaltung_Aufgabe_9;

internal class Tonie : Medium, ILaufzeit
{
    public double Laufzeit { get; set; }

    public override void DatenEingeben()
    {
        base.DatenEingeben();
        Console.WriteLine("Laufzeit eingeben:");
        Laufzeit = Convert.ToDouble(Console.ReadLine());
    }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Dauer {4:F2} min", Signatur, nameof(Tonie), Titel.Length > 15 ? Titel.Substring(0, 15) : Titel, Status, Laufzeit);
    }
}