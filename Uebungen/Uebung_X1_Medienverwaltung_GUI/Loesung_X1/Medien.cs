using System;


namespace Medienauswahl_Aufgabe_GUI
{
    public class Medien
    {
        private Leihstatus leihstatusMedien;
        private int signatur = 0;
        private String titel;
        private TypBezeichnung typ;

        public enum Leihstatus 
        {
            präsent,
            entliehen
        };

        public enum TypBezeichnung
        {
            Video,
            Buch,
            Zeitschrift
        };

        public Medien(string titel, Leihstatus leihstatus, TypBezeichnung typBezeichnung)
        {
            Signatur = GenerateSignatur();
            LeihstatusMedien = leihstatus;
            Titel = titel;
            Typ = typBezeichnung;

            Data.AddData(Signatur, this);
        }

        public int Signatur {
            get { return signatur; }
            set { signatur = value; }
        }

        public string Titel {
            get { return titel; }
            set { titel = value; }
        }

        public TypBezeichnung Typ {
            get { return typ; }
            set { typ = value; }
        }

        public Leihstatus LeihstatusMedien {
            get { return leihstatusMedien; }
            set { leihstatusMedien = value; }
        }

        internal void Entleihen() 
        {
            if (leihstatusMedien == Leihstatus.präsent)
            {
                leihstatusMedien = Leihstatus.entliehen;
                Console.WriteLine(titel + " efolgreich ausgeliehen.");
            }
            else {
                throw new StatusErrorException(signatur.ToString());
            }
        }

        internal void Rueckgabe() 
        { 
            if (leihstatusMedien == Leihstatus.entliehen)
            {
                leihstatusMedien = Leihstatus.präsent;
                Console.WriteLine(titel + " efolgreich zurueckgegeben.");
            }
            else
            {
                throw new StatusErrorException(signatur.ToString());
            }
        }

        private int GenerateSignatur()
        {
            Random random = new Random();
            int newKey = 0;

            do
            {
                newKey = random.Next(1000, 100000);
            } while (!Data.IsKeyEindeutig(newKey));

            return newKey;
        }
    }
}
