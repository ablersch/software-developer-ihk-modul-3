using Microsoft.EntityFrameworkCore;

namespace Medienverwaltung_Aufgabe_9;

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
            // Signatur als Key definieren
            entity.HasKey(b => b.Signatur);
            // Signatur soll nicht durch die Datenbank erzeugt werden
            entity.Property(b => b.Signatur).ValueGeneratedNever();

            // Hinzufügen einer Diskriminatorspalte zur Identifizierung
            entity.HasDiscriminator<string>("Type")
                .HasValue<Buch>("Buch")
                .HasValue<Tonie>("Tonie")
                .HasValue<Video>("Video");
        });

        // Gemeinsame Eigenschaften für ILaufzeit-Implementieren
        modelBuilder.Entity<Video>().Property(v => v.Laufzeit).HasColumnName("Laufzeit");
        modelBuilder.Entity<Tonie>().Property(v => v.Laufzeit).HasColumnName("Laufzeit");
    }
}