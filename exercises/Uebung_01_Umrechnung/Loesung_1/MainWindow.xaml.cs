using System.Windows;

namespace Umrechnung;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnC2F_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(tbxGrad.Text))
        {
            if (double.TryParse(tbxGrad.Text, out double input))
            {
                input = (input*9/5) + 32;
                input = Math.Round(input, 2);

                tbxResult.Text = $"{input} F";
            }
            else
            {
                MessageBox.Show("Bitte nur Zahlen eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Bitte eine Zahl eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void btnF2C_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(tbxGrad.Text))
        {
            if (double.TryParse(tbxGrad.Text, out double input))
            {
                input = ((input - 32)*5)/9;
                input = Math.Round(input, 2);

                tbxResult.Text = $"{input} C";
            }
            else
            {
                MessageBox.Show("Bitte nur Zahlen eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Bitte eine Zahl eingeben", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}