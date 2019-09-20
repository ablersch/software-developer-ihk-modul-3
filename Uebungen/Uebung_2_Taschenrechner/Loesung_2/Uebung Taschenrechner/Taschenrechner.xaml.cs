using System;
using System.Windows;
using System.Windows.Controls;

namespace Uebung_Taschenrechner
{
    public partial class MainWindow : Window
    {
        private double oldValue = 0;
        private double calculationResult = 0;
        private string operatorValue;

        public MainWindow()
        {
            InitializeComponent();
            tbxInput.Focus();
        }

        private void btnErgebnis_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            tbxInput.Text = calculationResult.ToString();
        }

        private void Calculate()
        {
            if (tbxInput.Text != "")
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
                            MessageBox.Show("Durch 0 teilen nicht erlaubt!!");
                        }
                        break;

                    case "*":
                        calculationResult = oldValue * newValue;
                        break;
                }

                oldValue = 0;
                operatorValue = "";
                lblTempValue.Content += tbxInput.Text + " = " + calculationResult + "  ";
                ToogleOperatorButtons();
                tbxInput.Focus();
            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            oldValue = 0;
            operatorValue = "";
            lblTempValue.Content = "";
            tbxInput.Text = "";
        }

        /// <summary>
        /// Click Event für alle Buttons der Berechnungsarten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            btnName = btnName.Substring(3);

            lblTempValue.Content += tbxInput.Text;
            if (!double.TryParse(tbxInput.Text, out oldValue))
            {
                return;
            }

            tbxInput.Text = "";

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

        /// <summary>
        /// Operator Tasten aktivieren oder deaktivieren
        /// </summary>
        private void ToogleOperatorButtons()
        {
            btnDivision.IsEnabled = !btnDivision.IsEnabled;
            btnAddition.IsEnabled = !btnAddition.IsEnabled;
            btnMultiplikation.IsEnabled = !btnMultiplikation.IsEnabled;
            btnSubtraktion.IsEnabled = !btnSubtraktion.IsEnabled;
        }

        /// <summary>
        /// Prüfen ob die Eingabe erlaubt ist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbxInput_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Festlegen ob die Eingabe (das Event) weitergeleitet werden soll
            e.Handled = !IsNumber(e.Text);
        }

        /// <summary>
        /// Prüfen ob Zahl eingeben wurde
        /// </summary>
        /// <param name="text">Eingebener Wert</param>
        /// <returns>true = Ist eine Zahl; false = kein Zahl</returns>
        private static bool IsNumber(string text)
        {
            return double.TryParse(text, out double tempValue);
        }
    }
}