using System.ComponentModel.DataAnnotations;

namespace EntityFramework;

public class Book
{
    [MaxLength(50)]
    public string Author { get; set; }

    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; }

    public int Year { get; set; }
}