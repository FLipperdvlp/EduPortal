using EduPortal.DataBase.Configurations;
using Microsoft.EntityFrameworkCore;
using EduPortal.Entities;

namespace EduPortal.DataBase;

public sealed class AppDbContext : DbContext
{
    public required DbSet<Student> Students { get; set; }
    public required DbSet<Teacher> Teachers { get; set; }
    public required DbSet<Course> Courses { get; set; }
    public required DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = EduPortal.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
    }
}