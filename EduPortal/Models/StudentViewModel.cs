namespace EduPortal.Models;

public class StudentViewModel
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public List<string>? Courses { get; set; }
}