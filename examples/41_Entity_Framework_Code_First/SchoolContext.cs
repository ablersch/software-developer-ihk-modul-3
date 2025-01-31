using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Datenbankverbindung konfigurieren
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = EF_Test2; Integrated Security = true;");
    }
}