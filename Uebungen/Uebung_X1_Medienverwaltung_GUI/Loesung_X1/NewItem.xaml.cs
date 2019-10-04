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
using System.Windows.Shapes;

namespace Medienauswahl_Aufgabe_6_GUI {
    /// <summary>
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : Window {
        public NewItem() {
            InitializeComponent();
            cbMedientyp.ItemsSource = Enum.GetValues(typeof(Medien.TypBezeichnung)).Cast<Medien.TypBezeichnung>();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            // TODO Button aktivieren wenn alle Felder ausgefüllt

            // check all fields

            switch (cbMedientyp.SelectedValue.ToString())
            {

                case "Buch":
                    Buecher buch = new Buecher(tbTitel.Text, tbEigenschaft.Text);
                    lblSignatur.Content = buch.Signatur.ToString();
                    break;

                case "Video":
                    Videos vid = new Videos();
                    //vid.Laufzeit = Convert.ToDouble(tbEigenschaft.Text);
                    lblSignatur.Content = vid.Signatur.ToString();
                    break;

                case "Zeitschrift":
                    Zeitschriften zeit = new Zeitschriften();
                    lblSignatur.Content = zeit.Signatur.ToString();
                    break;
            }

            this.Close();
        }

        private void cbMedientyp_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //MessageBox.Show(cbMedientyp.SelectedValue.ToString());

            //switch (cbMedientyp.SelectedValue.ToString()) {
                
            //    case "Buch":
            //        Buecher buch = new Buecher();
            //        lblSignatur.Content = buch.Signatur.ToString();
            //        break;

            //    case "Video":
            //        Videos vid = new Videos();
            //        //vid.Laufzeit = Convert.ToDouble(tbEigenschaft.Text);
            //        lblSignatur.Content = vid.Signatur.ToString();
            //        break;

            //    case "Zeitschrift":
            //        Zeitschriften zeit = new Zeitschriften();
            //        lblSignatur.Content = zeit.Signatur.ToString();
            //        break;
            //}
        }
    }
}
