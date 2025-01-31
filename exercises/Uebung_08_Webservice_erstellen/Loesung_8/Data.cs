using API_erstellen.Models;
using Serilog;

namespace API_erstellen;

public static class Data
{
    public static Dictionary<int, Medium> MedienDic = new Dictionary<int, Medium>
    {
        { 1111, new Medium{ Titel= "Herr der Ringe", Signatur = 1111, Status = Leihstatus.präsent } },
        { 2222, new Medium{ Titel= "Venum", Signatur = 2222, Status = Leihstatus.präsent } },
        { 3333, new Medium{ Titel= "Titanic", Signatur = 3333, Status = Leihstatus.präsent } },
    };

    /// <summary>
    /// Ein Medium Objekt aus dem Dictionary liefern.
    /// </summary>
    /// <param name="key">Signatur</param>
    /// <returns>Medien Objekt; Bei Fehler null</returns>
    public static Medium GetElement(int key)
    {
        if (MedienDic.TryGetValue(key, out var medium))
        {
            return medium;
        }
        else
        {
            Log.Warning($"Signatur '{key}' nicht gefunden!");
            return null;
        }
    }
}