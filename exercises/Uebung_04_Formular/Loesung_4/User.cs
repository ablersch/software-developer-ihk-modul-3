using System.ComponentModel;

namespace Formular;

public class User : INotifyPropertyChanged
{
    private int age;
    private string name;
    private string result;

    public event PropertyChangedEventHandler PropertyChanged;

    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            OnPropertyChanged(nameof(age));
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnPropertyChanged(nameof(name));
        }
    }

    public string Result
    {
        get { return result; }
        set
        {
            result = value;
            OnPropertyChanged(nameof(Result));
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}