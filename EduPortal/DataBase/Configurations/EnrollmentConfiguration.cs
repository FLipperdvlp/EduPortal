using EduPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.DataBase.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.EnrollmentId);
        builder.Property(e => e.EnrollmentDate).IsRequired();
        builder.Property(e => e.Grade).HasPrecision(5, 2);

        builder.HasData(
            new Enrollment
            {
                EnrollmentId = 1,
                CourseId = 1,
                StudentId = 1,
                EnrollmentDate = new DateTime(2025, 1, 1)
            },
            new Enrollment
            {
                EnrollmentId = 2,
                CourseId = 2,
                StudentId = 2,
                EnrollmentDate = new DateTime(2025, 1, 1)
            },
            new Enrollment
            {
                EnrollmentId = 3,
                CourseId = 3,
                StudentId = 3,
                EnrollmentDate = new DateTime(2025, 1, 1)
            }
        );
    }
}