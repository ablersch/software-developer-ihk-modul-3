# Übung - Medienverwaltung SQL

Die letzte Aufgabe der Medienverwaltung soll nun umgebaut werden damit die Daten nicht mehr in einer JSON-Datei gespeichert werden sondern mit dem Entity Framework in einer SQL Tabelle gespeichert werden.

## Teil 1 - Projekt vorbereiten

Das Entity Framework benötigt einen leeren Standard-Konstruktor. Deshalb alle Konstruktoren entfernen. Die Eingabedaten welche aktuell in den Konstruktoren abgefragt werden in Methoden auslagern.

Die Grundfunktion der Anwendung soll gleich bleiben. Nicht mehr benötigte Codestellen entfernen. Versuchen Sie so wenig wie möglich zu verändern.

## Teil 2 - Datenbankzugriff

Es bietet sich an für den Datenbankzugriff das Entity Framework zu benutzen. Erstellen Sie anhand von Migrationen eine neue Tabelle im lokalen SQL Server von Visual Studio.

Stellen Sie das Projekt so um, das die Daten aus der SQL Tabelle gelesen und in die Tabelle geschrieben werden.

### Tabellenspalten

![Spalten](Spalten.png)

### DbContext

```csharp
internal class MedienverwaltungContext : DbContext
{
    public MedienverwaltungContext()
    {
    }

    public DbSet<Medium> Medien { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Medienverwaltung; Integrated Security=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medium>(entity =>
        {
            // Signatur als Key definieren.
            entity.HasKey(b => b.Signatur);
            // Signatur soll nicht durch die Datenbank erzeugt werden.
            entity.Property(b => b.Signatur).ValueGeneratedNever();

            // Hinzufügen einer Diskriminatorspalte zur Identifizierung.
            entity.HasDiscriminator<string>("Type")
                .HasValue<Buch>("Buch")
                .HasValue<Tonie>("Tonie")
                .HasValue<Video>("Video");
        });

        // Gemeinsame Eigenschaften für ILaufzeit-Implementieren.
        modelBuilder.Entity<Video>().Property(v => v.Laufzeit).HasColumnName("Laufzeit");
        modelBuilder.Entity<Tonie>().Property(v => v.Laufzeit).HasColumnName("Laufzeit");
    }
}
```
