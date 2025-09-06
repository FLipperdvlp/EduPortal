using EduPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.DataBase.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.TeacherId);
        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
        builder.Property(t => t.PhoneNumber).HasMaxLength(15);
        builder.Property(t => t.Specialization).IsRequired().HasMaxLength(100);
    
        builder.HasData(
            new Teacher
            {
                TeacherId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Specialization = "Math"
            },
            new Teacher
            {
                TeacherId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "0987654321",
                Specialization = "Science"
            },
            new Teacher
            {
                TeacherId = 3,
                FirstName = "Jim",
                LastName = "Beam",
                Email = "jim.beam@example.com",
            }
        );
    }
}