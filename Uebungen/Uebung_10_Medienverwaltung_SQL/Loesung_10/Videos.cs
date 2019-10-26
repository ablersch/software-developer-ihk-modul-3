using System;

namespace Medienauswahl_Aufgabe_3
{
    class Videos : Medien
    {
        private double laufzeit;

        public double Laufzeit
        {
            get { return laufzeit; }
            set { laufzeit = value; }
        }

        public Videos()
        {
            Typ = TypBezeichnung.Video;
            
            Console.WriteLine("Laufzeit eingeben:");
            laufzeit = Convert.ToDouble(Console.ReadLine());

            Data.AddData(Signatur, this);
        }

        public Videos(int signatur, string titel, string eigenschaft, TypBezeichnung typ, LeihstatusBezeichnung leihstatus):base("Platzhalter")
        {
            Signatur = signatur;
            Titel = titel;
            // TODO Fehlerprüfung
            Laufzeit = Convert.ToDouble(eigenschaft);
            Leihstatus = leihstatus;
            Typ = typ;
        }

        internal new void List()
        {
            Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} Dauer {4:F2} min", Signatur, Typ, (Titel.Length > 12) ? Titel.Substring(0, 12): Titel, Leihstatus, laufzeit);
        }
    }
}
