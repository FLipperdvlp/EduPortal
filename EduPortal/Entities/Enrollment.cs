namespace EduPortal.Entities;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    public string CourseName { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public int StudentId { get; set; }
    
    public DateTime EnrollmentDate { get; set; }
    public decimal? Grade { get; set; }
    
    public Course? Course { get; set; }
    public Student? Student { get; set; }    
}