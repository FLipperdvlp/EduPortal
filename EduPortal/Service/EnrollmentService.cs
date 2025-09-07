using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Service;

public class EnrollmentService(AppDbContext ctx) : IEnrollmentService
{
    public async Task<IEnumerable<Enrollment?>> GetAllEnrollmentsAsync()
    {
        return await ctx.Enrollments.ToListAsync();
    }

    public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
    {
        return await ctx.Enrollments.FindAsync(id);
    }

    public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
    {
        ctx.Enrollments.Add(enrollment);
        
        await ctx.SaveChangesAsync();
        
        return enrollment;
    }

    public async Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment)
    {
        var existing = await ctx.Enrollments.FindAsync(enrollment.EnrollmentId);

        if (existing == null) return null;
        
        existing.StudentId = enrollment.StudentId;
        existing.CourseId = enrollment.CourseId;
        existing.EnrollmentDate = enrollment.EnrollmentDate;
        existing.Grade = enrollment.Grade;
        
        await ctx.SaveChangesAsync();
        
        return existing;
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        var enrollment = await ctx.Enrollments.FindAsync(id);
        
        if(enrollment == null) return false;
        
        ctx.Enrollments.Remove(enrollment);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
    {
        return await ctx.Enrollments
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
    {
        return await ctx.Enrollments
            .Where(e => e.CourseId == courseId)
            .ToListAsync();
    }
}