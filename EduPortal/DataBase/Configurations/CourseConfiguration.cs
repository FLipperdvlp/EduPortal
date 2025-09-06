using EduPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.DataBase.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.CourseId);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
        builder.Property(c => c.StartDate).IsRequired();
        builder.Property(c => c.EndDate).IsRequired();

        builder.HasData(
            new Course
            {
                CourseId = 1,
                Title = "Math",
                Description = "Math is a subject that deals with numbers and shapes.",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                TeacherId = 1
            },
            new Course
            {
                CourseId = 2,
                Title = "English",
                Description = "English is a subject that deals with the English language.",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                TeacherId = 2
            },
            new Course
            {
                CourseId = 3,
                Title = "Science",
                Description = "Science is a subject that deals with the natural world.",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                TeacherId = 3
            }
        );
    }
}