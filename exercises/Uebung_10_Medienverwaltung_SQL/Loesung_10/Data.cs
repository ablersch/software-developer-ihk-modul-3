using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Medienverwaltung_Aufgabe_9;

internal static class Data
{
    /// <summary>
    /// Daten speichern.
    /// </summary>
    /// <param name="medium">Das zu speichernde Medium.</param>
    internal static void AddElement(Medium medium)
    {
        using var context = new MedienverwaltungContext();
        context.Medien.Add(medium);
        context.SaveChanges();
    }

    /// <summary>
    /// Prüfen ob ein Element mit der angegebenen Signatur existiert.
    /// </summary>
    /// <param name="signatur">Die Signatur auf welche geprüft werden soll.</param>
    /// <returns>
    ///   <c>true</c> wenn es die Signatur gibt; ansonsten <c>false</c>.
    /// </returns>
    internal static bool ContainsKey(int signatur)
    {
        using var context = new MedienverwaltungContext();
        return context.Medien.Any(x => x.Signatur == signatur);
    }

    /// <summary>
    /// Löscht ein Element.
    /// </summary>
    /// <param name="signatur">Signatur des Elements.</param>
    internal static void DeleteElement(int signatur)
    {
        var medium = GetElement(signatur);
        if (medium != null)
        {
            using var context = new MedienverwaltungContext();
            context.Medien.Remove(medium);
            context.SaveChanges();
            Console.WriteLine($"Medium mit der Signatur: {signatur} erfolgreich gelöscht.");
        }
    }

    /// <summary>
    /// Liefert alle Elemente.
    /// </summary>
    /// <returns>Liste aller Elemente.</returns>
    internal static List<Medium> GetAllElements()
    {
        using var context = new MedienverwaltungContext();
        return context.Medien.OrderBy(o => o.Titel).ToList();
    }

    /// <summary>
    /// Ein Medium mit einer bestimmten Signatur abrufen.
    /// </summary>
    /// <param name="key">Signatur welche abgerufen werden soll.</param>
    /// <returns>Ein Medien Objekt; bei Fehler null.</returns>
    internal static Medium GetElement(int signatur)
    {
        using var context = new MedienverwaltungContext();
        var medium = context.Medien.FirstOrDefault(x => x.Signatur == signatur);
        if (medium is null)
        {
            Log.Warning($"Signatur '{signatur}' nicht gefunden!");
        }
        return medium;
    }

    /// <summary>
    /// Ein bestehendes Element updaten.
    /// </summary>
    /// <param name="medium">Das upgedatete Element.</param>
    internal static void UpdateElement(Medium medium)
    {
        using var context = new MedienverwaltungContext();
        context.Update(medium);
        context.SaveChanges();
    }
}