using System.Collections.ObjectModel;
using System.Windows;

namespace ObservableCollection;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MedienCollection = new ObservableCollection<Medien>
        {
            new("Medium 1", 12345),
            new("Medium 2", 12222),
        };

        lsvView.ItemsSource = MedienCollection;
    }

    public ObservableCollection<Medien> MedienCollection { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MedienCollection.Add(new Medien("Medium 3", 6666));
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        MedienCollection.RemoveAt(0);
    }
}