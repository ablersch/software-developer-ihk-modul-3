namespace Medienauswahl_Aufgabe_GUI
{
    class Zeitschriften : Medien
    {
        public int Eigenschaft { get; set; }

        public Zeitschriften(string titel, int seitenzahl, Leihstatus leihstatus)
            : base(titel, leihstatus, TypBezeichnung.Zeitschrift)
        {
            Eigenschaft = seitenzahl;
        }
    }
}
