using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Service;

public class TeacherService(AppDbContext ctx) : ITeacherService
{
    public async Task<IEnumerable<Teacher?>> GetAllTeachersAsync()
    {
        return await ctx.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
    {
        return await ctx.Teachers.FindAsync(id);
    }

    public async Task<Teacher?> AddTeacherAsync(Teacher teacher)
    {
        ctx.Teachers.Add(teacher);
        
        await ctx.SaveChangesAsync();

        return teacher;
    }

    public async Task<Teacher?> UpdateTeacherAsync(Teacher teacher)
    {
        var existing = await ctx.Teachers.FindAsync(teacher.TeacherId);

        if (existing == null) return null!;
        
        existing.FirstName = teacher.FirstName;
        existing.LastName = teacher.LastName;
        existing.Email = teacher.Email;
        existing.PhoneNumber = teacher.PhoneNumber;
        existing.Specialization = teacher.Specialization;
        
        await ctx.SaveChangesAsync();
        
        return existing;
    }

    public async Task<bool> DeleteTeacherAsync(int id)
    {
        var teacher = await ctx.Teachers.FindAsync(id);
        
        if(teacher == null) return false;
        
        ctx.Teachers.Remove(teacher);
        await ctx.SaveChangesAsync();
        
        return true;
    }
}