using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Medienauswahl_Aufgabe_GUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            lstView.ItemsSource = Data.GetAllElements();          
        }

        private void btnNewItem_Click(object sender, RoutedEventArgs e) {
            Item newItemWindow = new Item();
            newItemWindow.ShowDialog();

            lstView.ItemsSource = Data.GetAllElements();
        }

        private void lstView_PreviewMouseLeftButtonDown(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem;
            if (selectedItem != null) {

                Item editItem = new Item(selectedItem as Medien);
                editItem.ShowDialog();
            }
        }
    }
}
