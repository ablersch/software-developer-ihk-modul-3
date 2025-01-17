namespace ObservableCollection;

public class Medien
{
    public Medien(string titel, int signatur)
    {
        Titel = titel;
        Signatur = signatur;
    }

    public int Signatur { get; set; }
    public string Titel { get; set; }
}