using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Service;

public class StudentService(AppDbContext context) : IStudentService
{
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await context.Students.FindAsync(id);
    }

    public async Task<Student?> AddStudentAsync(Student? student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        var existing = await context.Students.FindAsync(student.StudentId);
        
        if (existing == null) return null!;

        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Email = student.Email;
        existing.PhoneNumber = student.PhoneNumber;
        existing.DateOfBirth = student.DateOfBirth;

        await context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        
        if (student == null) return false;

        context.Students.Remove(student);
        await context.SaveChangesAsync();
        
        return true;
    }
}