using System.ComponentModel.DataAnnotations;
using EduPortal.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Entities;

public class Teacher : BaseEntityForPerson
{
    public int TeacherId { get; set; }
    
    public string Specialization { get; set; } = null!;
    
    public ICollection<Course>? Courses { get; set; }
}