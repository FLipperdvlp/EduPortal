using EduPortal.Entities;

namespace EduPortal.Interface;

public interface IEnrollmentService
{
    Task<IEnumerable<Enrollment?>> GetAllEnrollmentsAsync();
    Task<Enrollment?> GetEnrollmentByIdAsync(int id);
    Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
    Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment);
    Task<bool> DeleteEnrollmentAsync(int id);

    Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
    Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
}