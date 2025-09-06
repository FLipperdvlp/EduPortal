using System.ComponentModel.DataAnnotations;
using EduPortal.Entities.BaseEntities;

namespace EduPortal.Entities;

public class Student : BaseEntityForPerson
{
    public int StudentId { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public ICollection<Enrollment>? Enrollments { get; set; }
}