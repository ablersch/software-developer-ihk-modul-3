using System.Windows;

namespace Binding;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Medien medien;

    public MainWindow()
    {
        InitializeComponent();

        medien = new Medien("Medium 1", 12345);
        // Datenquelle festlegen
        DataContext = medien;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        medien.Titel = "Button geklickt";
        medien.Signatur = 111;
    }
}