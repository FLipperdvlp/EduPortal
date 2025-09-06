using EduPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.DataBase.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
        builder.Property(s => s.DateOfBirth).IsRequired();
        builder.Property(s => s.PhoneNumber).HasMaxLength(15);

        builder.HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);

        builder.HasData(
            new Student
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "1234567890"
            },
            new Student
            {
                StudentId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1992, 2, 2),
                PhoneNumber = "0987654321"
            },
            new Student
            {
                StudentId = 3,
                FirstName = "Jim",
                LastName = "Beam",
                Email = "jim.beam@example.com",
                DateOfBirth = new DateTime(1994, 3, 3),
                PhoneNumber = "1111111111"
            }
        );
    }
}