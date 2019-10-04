namespace Medienauswahl_Aufgabe_GUI
{
    class Videos : Medien
    {
        public double Eigenschaft { get; set; }

        public Videos(string titel, double laufzeit, Leihstatus leihstatus)
            : base(titel, leihstatus, TypBezeichnung.Video)
        {
            Eigenschaft = laufzeit;
        }
    }
}
