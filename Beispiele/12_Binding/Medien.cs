namespace Binding
{
    class Medien
    {
        public string Titel { get; set; }

        public int Signatur { get; set; }

        public Medien(string titel, int sig)
        {
            Titel = titel;
            Signatur = sig;
        }
    }
}
