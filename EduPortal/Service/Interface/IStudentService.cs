using EduPortal.Entities;

namespace EduPortal.Interface;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task<Student?> AddStudentAsync(Student? student);
    Task<Student> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
}