namespace CodeFirst;

internal class Program
{
    private static void Main(string[] args)
    {
        var student = new Student
        {
            Name = "Max Mustermann",
            EnrollmentDate = DateTime.Now,
        };

        using var context = new SchoolContext();

        // Fügt einen neuen Studenten hinzu
        context.Students.Add(student);

        // Änderungen in der Datenbank speichern
        context.SaveChanges();

        // Daten aus der Datenbank mit LINQ abrufen
        var students = context.Students.Where(x => x.Name.StartsWith("Max"));
    }
}