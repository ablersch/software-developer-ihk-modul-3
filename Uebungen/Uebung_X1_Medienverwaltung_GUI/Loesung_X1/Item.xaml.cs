using System;
using System.Linq;
using System.Windows;

namespace Medienauswahl_Aufgabe_GUI {

    public partial class Item : Window {

        public Item() {
            InitializeComponent();
            cbxMedientyp.ItemsSource = Enum.GetValues(typeof(Medien.TypBezeichnung)).Cast<Medien.TypBezeichnung>();
            cbxLeihstatustyp.ItemsSource = Enum.GetValues(typeof(Medien.Leihstatus)).Cast<Medien.Leihstatus>();
        }

        public Item(Medien medium) : this()
        { 
            DataContext = medium;

            lblSignatur.Visibility = Visibility.Visible;
            lblSignaturLabel.Visibility = Visibility.Visible;
            Title = "Medium bearbeiten";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            bool inputError = false;
            // TODO bei bestehenden Elementen nichts speichern!
            switch (cbxMedientyp.SelectedValue.ToString())
            {
                case "Buch":
                    int seitenzahl;
                    if (Int32.TryParse(tbxEigenschaft.Text, out seitenzahl))
                    {
                        new Buecher(tbxTitel.Text, seitenzahl, (Medien.Leihstatus)cbxLeihstatustyp.SelectedValue);
                    } else
                    {
                        MessageBox.Show("Als Eigenschaft (Seitenzahl) sind nur Zahlen erlaubt!");
                        inputError = true;
                    }    
                    break;

                case "Video":                   
                    double laufzeit;
                    if (Double.TryParse(tbxEigenschaft.Text, out laufzeit))
                    {
                        new Videos(tbxTitel.Text, laufzeit,(Medien.Leihstatus)cbxLeihstatustyp.SelectedValue);
                    }
                    else
                    {
                        MessageBox.Show("Als Eigenschaft (Laufzeit) sind nur Zahlen erlaubt");
                        inputError = true;
                    }

                    break;

                case "Zeitschrift":

                    if (Int32.TryParse(tbxEigenschaft.Text, out seitenzahl))
                    {
                        new Zeitschriften(tbxTitel.Text, seitenzahl, (Medien.Leihstatus)cbxLeihstatustyp.SelectedValue);
                    }
                    else
                    {
                        MessageBox.Show("Als Eigenschaft (Seitenzahl) sind nur Zahlen erlaubt");
                        inputError = true;
                    }
                    break;
            }

            if (!inputError)
            {
                Close();
            }
        }
    }
}
