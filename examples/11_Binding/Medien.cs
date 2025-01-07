using System.ComponentModel;

namespace Binding;

internal class Medien : INotifyPropertyChanged
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

    public string Titel { get; set; }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}