# Entity Framework

Entity Framework für Datenbankzugriffe.

---

<!-- .slide: class="left" -->
## Datenbank

Eine Datenbank ist ein elektronisches Verwaltungssystem, das besonders mit großen Datenmengen effizient, widerspruchsfrei, dauerhaft umgehen muss und logische Zusammenhänge digital abbilden kann.

Es können Datenbestände aus verschiedenen Teilmengen zusammengestellt und bedarfsgerecht für Anwendungsprogramme und deren Benutzern angezeigt werden.

---

<!-- .slide: class="left" -->
## Entity Framework

Das [Entity Framework](https://docs.microsoft.com/de-de/ef/) ist ein Framework für objektrelationale Abbildungen (ORM = Object-Relational Mapping).

Es erleichtert die Arbeit mit Datenbanken, indem es Entwicklern ermöglicht, mit Objekten und LINQ zu arbeiten, anstatt direkten SQL-Abfragen. Mit dem Entity Framework wird der Datenbankzugriff abstrahiert, wodurch der Entwickler sich mehr auf die Anwendungslogik konzentrieren kann.

Note: 

* Klassen werden auf Tabellen, oder auch andersrum, gemappt.
* Bei Java: Hibernate; bei PHP: Doctrine.
* Über NuGet installieren

---

<!-- .slide: class="left" -->
### Architektur

![Datenzugriff einer Anwendung beim Entity Framework](Images/entityFramework.png)


Note: 
* Intern Zugriff auf die Daten über ADO.NET (EF ist im Wesentlichen eine Abstraktionsebene über ADO.NET, die den Umgang mit Datenbanken einfacher und objektorientierter macht)
* Zugriff mit ADO.NET ist schneller wie mit Entity Framework.

---

<!-- .slide: class="left" -->
### Vorteile
 
* **Abstraktion von SQL:** Entwickler können Datenbankoperationen mit LINQ oder Methodenaufrufen durchführen, ohne SQL direkt schreiben zu müssen.

* **Produktivität:** Schnellere Entwicklung durch automatisiertes Mapping von Datenbanktabellen auf C#-Klassen.

* **Portabilität:** Unterstützung verschiedener Datenbanksysteme (z. B. SQL Server, MySQL, PostgreSQL).

* **Automatische Migrationen:** Unterstützung für das Erstellen und Aktualisieren von Datenbanken basierend auf dem C#-Code.

---

<!-- .slide: class="left" -->
### zwei Ansätze

Es gibt verschiedene Implementierungen eine Datenbank zu nutzen:

* **Database-First:** Mit dem DB-First-Ansatz wird die Datenbank zuerst manuell oder über ein anderes Tool erstellt. Entity Framework generiert dann die entsprechenden C#-Klassen (Modelle), die mit dieser Datenbank verknüpft sind.

* **Code-First:** Mit dem Code-First-Ansatz definieren Sie die Datenbankstruktur direkt im Code als C#-Klassen. Entity Framework erstellt die Datenbank basierend auf diesen Klassen.

---

<!-- .slide: class="left" -->
### Migrationen bei Code-First Ansatz

Migrationen ermöglichen es, Änderungen am Datenmodellen (Klassen) automatisch in die Datenbank zu übertragen. Dabei ist keine manuell Erstellung/Anpassung an der DB notwendig.

1. **Migration erstellen:** `Add-Migration <Name>` generiert eine Datei, die die Änderungen am Schema beschreibt (z. B. das Erstellen von Tabellen).

2. **Migration anwenden:** Mit `Update-Database` werden die Änderungen auf die Datenbank angewendet.

3. **Nachträgliche Änderungen:** Wenn das Datenmodell geändert wird, können neue Migrationen hinzugefügt werden um das Schema zu aktualisieren.

4. **Entfernen von Migrationen:** Beim entfernen einer Migration muss zuerst die DB auf die vorletzte Migration zurückgesetzt werden: `Update-Database <Name>`. Dann kann die letzte Migration entfernt werden `Remove-Migration`.


Note:
* Migrations in der "Package Manager Console" ausführen
* Beim entfernen von Migrations muss die DB zuvor auf die vorletzte Migration zurückgesetzt werden

---

<!-- .slide: class="left" -->
### Entity Framework verwenden

* Folgende NuGet Pakete im Projekt installieren:
  * Microsoft.EntityFrameworkCore
  * Microsoft.EntityFrameworkCore.SqlServer
  * Microsoft.EntityFrameworkCore.Tools

* Model Struktur aufbauen
* DB-Kontext-Klasse hinzufügen 
* Optional bei Code-First Ansatz: Tabelle über Migration anlegen.
  * `Add-Migration <Name>`
  * `Update-Database`
* Zugriff auf die Daten über die DB-Kontext-Klasse mit z.B. LINQ
  
Note:
* Kontext Klasse: 
  * Stellt Verbindung zur Datenbank her. Benötigt Connection String (https://www.connectionstrings.com/).
  * Weiter Konfiguration für Datenbank Tabellen und Views möglich

---

<!-- .slide: class="left" -->
### Beispiel DbContext Klasse

```csharp []
// Verwaltet die Verbindung zur Datenbank.
public class MedienverwaltungContext : DbContext
{
    public MedienverwaltungContext()
    {
    }

    // Definiert eine Datenbank-Tabelle, die die Entität Medien repräsentiert.
    public DbSet<Medien> Medien { get; set; }

    // Wird beim Erstellen einer Instanz autom. aufgerufen.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Datenbankverbindung konfigurieren
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = Medienverwaltung; Integrated Security = true;");
    }
}
```

---

<!-- .slide: class="left" -->
### Beispiel

```csharp []
using (var context = new MedienverwaltungContext())
{
    // Daten lesen
    var list = context.Medien.ToList();

    // Daten löschen
    context.Medien.Remove(list[0]);
    context.SaveChanges();

    // Daten updaten
    list[0].Titel = "neuer Titel";
    context.SaveChanges();
}
```

```csharp []
// Daten schreiben
using (var context = new MedienverwaltungContext())
{
    var buch = new Buch();
    // Guid erzeugen
    buch.Id = Guid.NewGuid();
    buch.Titel = "neuer Buch Titel";

    context.Medien.Add(buch);
    context.SaveChanges();
}
```

Note:
* Zeigen in **VS** 41_Entity_Framework
  * neues Property hinzufügen z.B. `int Semester`
  * neue Migration erstellen und DB updaten
  * Feld wieder entfernen, DB zurücksetzen, Migration entfernen
* **ÜBUNG** EntityFramework

---

<!-- .slide: class="left" -->
## lokale SQL Server DB

Im Visual Studio kann für Entwicklungszwecke eine **SQL Server Express LocalDB** genutzt werden.

* Entwicklungsdatenbanken
* Integration mit Entity Framework
* SQL-Abfragen ausführen
* Migrations-Szenarien testen

Ansicht --> "Sql Server Objekt Explorer" öffnen

Mit Rechtsklick auf **Datenbanken** kann eine neue DB erzeugt werden.

Note: 
* **SQL Server Express LocalDB:** Dabei handelt es sich um eine leichte Version des Microsoft SQL Servers, die speziell für Entwickler entwickelt wurde, um Datenbanken lokal und ohne aufwändige Installation zu verwalten.
* Über Properties Daten abrufen wie ConnectionString und Speicherort

---

<!-- .slide: class="left" -->
### Projekt mit lokaler DB auf anderen Computer kopieren

1. Die *.mdf und *.ldf Dateien (Datenbankdateien) ebenfalls mit kopieren.

2. Die *.mdf und *.ldf Dateien in Visual Studio dem Projekt hinzufügen.

3. Im Projekt auf die *.mdf Datei klicken. Somit öffnet sich der SQL Server Objekt Explorer.

4. Nun muss der verwendete Connection String in eurem Projekt angepasst werden.
    1. Im SQL Server Objekt Explorer rechtsklick auf eure mdf Datei und Eigenschaften wählen.
    2. Im Eigenschaften Fenster kann dann der Connection String (Verbindungszeichenfolge) kopiert werden.
    3. Diesen in euer Projekt übernehmen.

5. Jetzt nutzt euer Projekt die lokale *.mdf Datei.