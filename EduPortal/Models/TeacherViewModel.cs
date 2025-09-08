namespace EduPortal.Models;

public class TeacherViewModel
{
    public int TeacherId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;

    public int CoursesCount { get; set; }
}