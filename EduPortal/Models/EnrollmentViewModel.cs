namespace EduPortal.Models;

public class EnrollmentViewModel
{
    public int EnrollmentId { get; set; }

    public string StudentName { get; set; } = string.Empty;
    public string CourseTitle { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }
    public decimal? Grade { get; set; }
}