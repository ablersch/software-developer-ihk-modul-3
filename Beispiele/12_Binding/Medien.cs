using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    class Medien : INotifyPropertyChanged
    {
        private string titel;

        private int signatur;


        public string Titel
        {
            get { return titel; }
            set
            {
                titel = value;
                OnPropertyChanged("Titel");
            }
        }

        public int Signatur
        {
            get { return signatur; }
            set
            {
                signatur = value;
                OnPropertyChanged("Signatur");
            }
        }

        public Medien(string titel, int sig)
        {
            Titel = titel;
            Signatur = sig;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // Notwendig damit die GUI aktualisiert wird.
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
