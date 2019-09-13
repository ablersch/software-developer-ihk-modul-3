using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
