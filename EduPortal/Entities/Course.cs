using System.ComponentModel.DataAnnotations;

namespace EduPortal.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int TeacherId { get; set; }
    
    public Teacher? Teacher { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}