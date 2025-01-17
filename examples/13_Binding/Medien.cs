using System.ComponentModel;

namespace Binding;

public class Medien : INotifyPropertyChanged
{
    private int signatur;

    public Medien(string titel, int signatur)
    {
        Titel = titel;
        Signatur = signatur;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public int Signatur
    {
        get { return signatur; }
        set
        {
            signatur = value;
            OnPropertyChanged(nameof(Signatur));
        }
    }

    // Aktualisiert sich nicht automatisch da kein Aufruf von OnPropertyChanged.
    // Deshlab wird eine Änderung nicht an die UI weitergegeben.
    public string Titel { get; set; }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}