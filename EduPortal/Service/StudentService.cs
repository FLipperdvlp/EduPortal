using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Service;

public class StudentService(AppDbContext _context) : IStudentService
{
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student?> UpdateStudentAsync(Student student)
    {
        var existing = await _context.Students.FindAsync(student.StudentId);
        if (existing == null) return null;

        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Email = student.Email;
        existing.PhoneNumber = student.PhoneNumber;
        existing.DateOfBirth = student.DateOfBirth;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return false;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}