using System.Windows;

namespace Binding;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        TestMedium = new Medien("Medium 1", 12345);

        // Datenquelle festlegen
        DataContext = TestMedium;

        // Gesamtes Fenster (Zugriff im XAML über das Objekt: TestMedium)
        //DataContext = this;
    }

    public Medien TestMedium { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TestMedium.Titel = "Button geklickt";
        TestMedium.Signatur = 111;
    }
}