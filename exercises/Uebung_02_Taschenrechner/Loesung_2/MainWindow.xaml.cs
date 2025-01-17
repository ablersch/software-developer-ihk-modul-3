using System.Windows;
using System.Windows.Controls;

namespace Taschenrechner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double calculationResult = 0;
    private double oldValue = 0;
    private string operatorValue = string.Empty;

    public MainWindow()
    {
        InitializeComponent();
        tbxInput.Focus();
    }

    /// <summary>
    /// Click-Event für alle Buttons der Berechnungsarten.
    /// </summary>
    private void btn_Click(object sender, RoutedEventArgs e)
    {
        string btnName = ((Button)sender).Name;
        btnName = btnName.Substring(3);

        lblTempValue.Content += tbxInput.Text;
        if (!double.TryParse(tbxInput.Text, out oldValue))
        {
            return;
        }

        tbxInput.Text = string.Empty;

        switch (btnName)
        {
            case "Addition":
                lblTempValue.Content += " + ";
                operatorValue = "+";
                break;

            case "Subtraktion":
                lblTempValue.Content += " - ";
                operatorValue = "-";
                break;

            case "Division":
                lblTempValue.Content += " / ";
                operatorValue = "/";
                break;

            case "Multiplikation":
                lblTempValue.Content += " * ";
                operatorValue = "*";
                break;
        }

        ToogleOperatorButtons();
        tbxInput.Focus();
    }

    private void btnCE_Click(object sender, RoutedEventArgs e)
    {
        oldValue = 0;
        operatorValue = string.Empty;
        lblTempValue.Content = string.Empty;
        tbxInput.Text = string.Empty;
    }

    private void btnErgebnis_Click(object sender, RoutedEventArgs e)
    {
        Calculate();
        tbxInput.Text = calculationResult.ToString();
    }

    private void Calculate()
    {
        if (tbxInput.Text != string.Empty)
        {
            double newValue = Convert.ToDouble(tbxInput.Text);

            switch (operatorValue)
            {
                case "+":
                    calculationResult = oldValue + newValue;
                    break;

                case "-":
                    calculationResult = oldValue - newValue;
                    break;

                case "/":
                    // Teilen durch 0 nicht erlaubt
                    if (oldValue != 0 && newValue != 0)
                    {
                        calculationResult = oldValue / newValue;
                    }
                    else
                    {
                        MessageBox.Show("Durch 0 teilen ist nicht erlaubt.");
                    }
                    break;

                case "*":
                    calculationResult = oldValue * newValue;
                    break;
            }

            oldValue = 0;
            operatorValue = string.Empty;
            lblTempValue.Content += $"{tbxInput.Text} = {calculationResult} ";
            ToogleOperatorButtons();
            tbxInput.Focus();
        }
    }

    /// <summary>
    /// Prüfen ob die Eingabe erlaubt ist.
    /// </summary>
    private void TbxInput_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        // Ist die Eingabe erlaubt? Wenn nicht wird die Eingabe (Event) nicht weitergeleitet.
        e.Handled = !double.TryParse(e.Text, out double tempValue);
    }

    /// <summary>
    /// Operator Tasten aktivieren oder deaktivieren.
    /// </summary>
    private void ToogleOperatorButtons()
    {
        btnDivision.IsEnabled = !btnDivision.IsEnabled;
        btnAddition.IsEnabled = !btnAddition.IsEnabled;
        btnMultiplikation.IsEnabled = !btnMultiplikation.IsEnabled;
        btnSubtraktion.IsEnabled = !btnSubtraktion.IsEnabled;
    }
}