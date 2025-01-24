using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Buecher_Filter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ObservableCollection<Book> filteredBooks;
    private string filterText;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        // Beispiel-Daten
        Books = new ObservableCollection<Book>
        {
            new Book { Title = "Der Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
            new Book { Title = "1984", Author = "George Orwell", Year = 1949 },
            new Book { Title = "Die unendliche Geschichte", Author = "Michael Ende", Year = 1979 },
            new Book { Title = "Harry Potter und der Stein der Weisen", Author = "J.K. Rowling", Year = 1997 },
            new Book { Title = "Momo", Author = "Michael Ende", Year = 1973 },
            new Book { Title = "Der Herr der Ringe", Author = "J.R.R. Tolkien", Year = 1954 },
            new Book { Title = "Sturmhöhe", Author = "Emily Brontë", Year = 1847 },
            new Book { Title = "Faust", Author = "Johann Wolfgang von Goethe", Year = 1808 },
            new Book { Title = "Die Verwandlung", Author = "Franz Kafka", Year = 1915 },
            new Book { Title = "Der Alchimist", Author = "Paulo Coelho", Year = 1988 },
        };

        // Standard: Alle Bücher anzeigen
        FilteredBooks = new ObservableCollection<Book>(Books);
    }

    // Für PropertyChanged-Event
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<Book> Books { get; set; }

    public ObservableCollection<Book> FilteredBooks
    {
        get { return filteredBooks; }
        set
        {
            filteredBooks = value;
            OnPropertyChanged(nameof(FilteredBooks));
        }
    }

    public string FilterText
    {
        get { return filterText; }
        set
        {
            filterText = value;
            OnPropertyChanged(nameof(FilterText));
            // Filter anwenden, sobald sich der Text ändert
            ApplyFilter();
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ApplyFilter()
    {
        if (string.IsNullOrWhiteSpace(FilterText))
        {
            // Wenn kein Filtertext vorhanden ist, zeige alle Bücher
            FilteredBooks = new ObservableCollection<Book>(Books);
        }
        else
        {
            // Filtere die Bücherliste
            var lowerFilter = FilterText.ToLower();

            FilteredBooks = new ObservableCollection<Book>(Books.Where(book =>
                book.Title.ToLower().Contains(lowerFilter) ||
                book.Author.ToLower().Contains(lowerFilter) ||
                book.Year.ToString().Contains(lowerFilter)));
        }
    }
}