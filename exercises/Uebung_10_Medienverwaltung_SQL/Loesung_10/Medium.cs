using System;
using Serilog;

namespace Medienverwaltung_Aufgabe_9;

public abstract class Medium
{
    public int Signatur { get; set; }

    public Leihstatus Status { get; set; }

    public string Titel { get; set; }

    public virtual void DatenEingeben()
    {
        Signatur = SignaturErzeugen();

        Console.WriteLine("Titel eingeben:");
        Titel = Console.ReadLine();

        Status = Leihstatus.präsent;
    }

    internal static void AusgabeUeberschrift()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "Signatur", "Typ", "Titel", "Leihstatus", "Eigenschaften");
    }

    internal abstract void Ausgabe();

    internal void Entleihen()
    {
        if (Status == Leihstatus.präsent)
        {
            Status = Leihstatus.entliehen;
            Console.WriteLine(Titel + " efolgreich ausgeliehen.");
            Data.UpdateElement(this);
        }
        else
        {
            Log.Error($"Fehler beim Entleihen von Signatur '{Signatur}'.");
        }
    }

    internal void Rueckgabe()
    {
        if (Status == Leihstatus.entliehen)
        {
            Status = Leihstatus.präsent;
            Console.WriteLine(Titel + " efolgreich zurueckgegeben.");
            Data.UpdateElement(this);
        }
        else
        {
            Log.Error($"Fehler beim Rückgeben von Signatur '{Signatur}'.");
        }
    }

    protected string KurzerTitel()
    {
        return (Titel.Length > 15) ? Titel.Substring(0, 15) : Titel;
    }

    private static int SignaturErzeugen()
    {
        Random random = new();
        int newKey;
        do
        {
            newKey = random.Next(1000, 9999);
        } while (Data.ContainsKey(newKey));

        return newKey;
    }
}