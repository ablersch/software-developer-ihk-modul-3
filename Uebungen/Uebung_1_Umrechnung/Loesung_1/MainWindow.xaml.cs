using System;
using System.Windows;

namespace Uebung_Umrechnung{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnC2F_Click(object sender, RoutedEventArgs e) {
            double result;
            double input;
            
            if (!string.IsNullOrWhiteSpace(tbxGrad.Text)) {
                if (double.TryParse(tbxGrad.Text, out input)) {

                    result = (input*9/5) + 32;
                    result = Math.Round(result, 2);

                    tbxResult.Text = result.ToString() + " F";

                }
                else {
                    MessageBox.Show("Bitte nur Zahlen eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                MessageBox.Show("Bitte eine Zahl eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnF2C_Click(object sender, RoutedEventArgs e) {
            double result;
            double input;
            
            if (!string.IsNullOrWhiteSpace(tbxGrad.Text)) {
                if (double.TryParse(tbxGrad.Text, out input)) {

                    result = ((input - 32)*5)/9;
                    result = Math.Round(result, 2);

                    tbxResult.Text = result.ToString() + " C";
                }
                else {
                    MessageBox.Show("Bitte nur Zahlen eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                MessageBox.Show("Bitte eine Zahl eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
