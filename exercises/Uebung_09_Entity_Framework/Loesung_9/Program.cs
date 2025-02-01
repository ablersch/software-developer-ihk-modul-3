namespace EntityFramework;

internal class Program
{
    private static void AddBooks()
    {
        using var context = new LibraryDbContext();

        var books = new List<Book>
        {
            new Book { Title = "Herr der Ringe", Author = "J.R.R. Tolkien", Year = 1954 },
            new Book { Title = "Harry Potter", Author = "J.K. Rowling", Year = 1997 },
            new Book { Title = "1984", Author = "George Orwell", Year = 1949 }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }

    private static void Main(string[] args)
    {
        AddBooks();
        PrintAllBooks();
        PrintBooksFromAuthor("George Orwell");
        UpdateBook("J.K. Rowling", 2000);
    }

    private static void PrintAllBooks()
    {
        using var context = new LibraryDbContext();
        foreach (var book in context.Books)
        {
            Console.WriteLine($"{book.Title} von {book.Author} ({book.Year})");
        }
    }

    private static void PrintBooksFromAuthor(string author)
    {
        using var context = new LibraryDbContext();
        foreach (var book in context.Books.Where(b => b.Author == author).ToList())
        {
            Console.WriteLine($"{book.Title} von {book.Author} ({book.Year})");
        }
    }

    private static void UpdateBook(string title, int year)
    {
        using var context = new LibraryDbContext();
        var book = context.Books.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            book.Year = year;
            context.SaveChanges();
        }
    }
}