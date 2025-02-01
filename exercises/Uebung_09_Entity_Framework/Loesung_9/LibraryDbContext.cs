using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = Library; Integrated Security = true;");
    }
}