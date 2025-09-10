using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Service;

public class CourseService(AppDbContext context) : ICourseService
{
    public async Task<IEnumerable<Course?>> GetAllCoursesAsync()
    {
        return await context.Courses.ToListAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
    }

    public async Task<Course> AddCourseAsync(Course course)
    {
        context.Courses.Add(course);
        
        await context.SaveChangesAsync();
        return course;
    }

    public async Task<Course> UpdateCourseAsync(Course course)
    {
        var existing = await context.Courses.FindAsync(course.CourseId);
        
        if(existing is null) return null!;
        
        existing.Title = course.Title;
        existing.Description = course.Description;
        existing.Category = course.Category;
        existing.TeacherId = course.TeacherId;
        
        await context.SaveChangesAsync();
        
        return existing;
    }

    public async Task<bool> DeleteCourseByIdAsync(int id)
    {
        var course = await context.Courses.FindAsync(id);
        
        if(course is null) return false;
        
        context.Courses.Remove(course);
        await context.SaveChangesAsync();
        
        return true;
    }
}