namespace EduPortal.Models;

public class CourseViewModel
{
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public string TeacherName { get; set; } = string.Empty;
}