using System.Windows;

namespace Binding
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Medien medien;

        public MainWindow()
        {
            InitializeComponent();

            medien = new Medien("Titel eines Mediums", 12345);
            // Datenquelle festlegen
            DataContext = medien;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Button geklickt";
            medien.Signatur = 111;
        }
    }
}
