using System;
using System.Collections;

namespace Medienauswahl_Aufgabe_3
{
    class Medien
    {
        private LeihstatusBezeichnung leihstatus;
        private int signatur = 0;
        private String titel;
        private TypBezeichnung typ;

        public enum LeihstatusBezeichnung
        {
            präsent,
            entliehen
        };

        public enum TypBezeichnung
        {
            Video,
            Buch
        };

        public LeihstatusBezeichnung Leihstatus
        {
            get { return leihstatus; }
            set { leihstatus = value; }
        }

        public TypBezeichnung Typ
        {
            get { return typ; }
            set { typ = value; }
        }

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public int Signatur
        {
            get { return signatur; }
            set { signatur = value; }
        }


        public Medien()
        {
            Signatur = GenerateSignatur();

            Console.WriteLine("Titel eingeben:");
            Titel = Console.ReadLine();

            Leihstatus = LeihstatusBezeichnung.präsent;
        }

        //Leerer Konstruktor welcher beim anlegen von Medien aus der DB genutzt wird
        // 
        public Medien(string platzhalter)
        {
            // TODO Ändern
        }

        internal static void List()
        {
            Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}", "Signatur", "Typ", "Titel", "Leihstatus", "Eigenschaften");
        }

        internal void Entleihen()
        {
            if (leihstatus == LeihstatusBezeichnung.präsent)
            {
                Leihstatus = LeihstatusBezeichnung.entliehen;
                Data.ChangeElementLeihstatus(Signatur, Leihstatus);
                Console.WriteLine(titel + " efolgreich ausgeliehen.");
            }
            else
            {
                Console.WriteLine(titel + " ist bereits entliehen.");
            }
        }

        internal void Rueckgabe()
        {
            if (leihstatus == LeihstatusBezeichnung.entliehen)
            {
                Leihstatus = LeihstatusBezeichnung.präsent;
                Data.ChangeElementLeihstatus(Signatur, Leihstatus);
                Console.WriteLine(titel + " efolgreich zurueckgegeben.");
            }
            else
            {
                Console.WriteLine("Rueckgabe von " + titel + " nicht möglich da das Medium nicht entliehen ist.");
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
