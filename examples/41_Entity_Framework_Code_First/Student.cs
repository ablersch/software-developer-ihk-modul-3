using System.ComponentModel.DataAnnotations;

namespace EntityFramework;

public class Student
{
    public DateTime EnrollmentDate { get; set; }

    public string Name { get; set; }

    // Primärschlüssel
    [Key]
    public int StudentId { get; set; }
}