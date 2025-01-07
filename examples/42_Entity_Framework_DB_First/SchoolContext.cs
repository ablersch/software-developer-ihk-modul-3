using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    /// <summary>
    /// Gleicher Name wie die Datenbank
    /// </summary>
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Datenbankverbindung konfigurieren
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = EF_Test; Integrated Security = true;");
    }

    /// <summary>
    /// Weitere Konfiguration wie die Definition von Tabellen oder Views.
    /// </summary>
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Student>(entity =>
    //    {
    //        entity.ToView("StudentView", "dbo");
    //        entity.HasNoKey();
    //    });

    //    modelBuilder.Entity<Student>(entity =>
    //    {
    //        entity.ToTable("Student", "dbo");
    //    });
    //}
}