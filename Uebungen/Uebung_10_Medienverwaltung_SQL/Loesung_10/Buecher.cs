using System;

namespace Medienauswahl_Aufgabe_3
{
    class Buecher : Medien
    {
        private int seitenzahl;

        public int Seitenzahl
        {
            get { return seitenzahl; }
            set { seitenzahl = value; }
        }

        public Buecher()
        {
            Typ = TypBezeichnung.Buch;
            
            Console.WriteLine("Seitenzahl eingeben:");
            while (!Int32.TryParse(Console.ReadLine(), out seitenzahl) )
            {
                Console.WriteLine("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben:");
            }

            Data.AddData(Signatur, this);
        }

        public Buecher(int signatur, string titel, string eigenschaft, TypBezeichnung typ, LeihstatusBezeichnung leihstatus):base("platzhalter")
        {
            Signatur = signatur;
            Titel = titel;
            // TODO Fehlerprüfung
            Seitenzahl = Convert.ToInt32(eigenschaft);
            Leihstatus = leihstatus;
            Typ = typ;
        }

        internal new void List()
        {
            Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} Seitenzahl {4,-12}", Signatur, Typ, (Titel.Length > 12) ? Titel.Substring(0, 12) : Titel, Leihstatus, seitenzahl);
        }
    }
}
