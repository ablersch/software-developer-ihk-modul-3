//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uebung_SQL_Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Benutzer
    {
        public System.Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Login { get; set; }
        public string Geschlecht { get; set; }
        public Nullable<int> Alter { get; set; }
    }
}
