namespace Medienauswahl_Aufgabe_GUI
{
    class Buecher : Medien
    {
        public int Eigenschaft { get; set; }

        public Buecher(string titel, int seitenzahl, Leihstatus leihstatus)
            : base(titel, leihstatus, TypBezeichnung.Buch)
        {
            Eigenschaft = seitenzahl;
        }
    }
}
