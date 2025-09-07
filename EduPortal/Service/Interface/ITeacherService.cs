using EduPortal.Entities;

namespace EduPortal.Interface;

public interface ITeacherService
{
    Task<IEnumerable<Teacher?>> GetAllTeachersAsync();
    Task<Teacher?> GetTeacherByIdAsync(int id);
    Task<Teacher?> AddTeacherAsync(Teacher teacher);
    Task<Teacher?> UpdateTeacherAsync(Teacher teacher);
    Task<bool> DeleteTeacherAsync(int id);
}