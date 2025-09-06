using EduPortal.Entities;

namespace EduPortal.Interface;

public interface ICourseService
{
    Task<IEnumerable<Course?>> GetAllCoursesAsync();
    Task<Course?> GetCourseBuIdAsync(int id);
    Task<Course> AddCourseAsync(Course course);
    Task<Course> UpdateCourseAsync(Course course);
    Task<bool> DeleteCourseByIdAsync(int id);
}