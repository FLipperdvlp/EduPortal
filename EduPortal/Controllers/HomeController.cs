using EduPortal.DataBase;
using EduPortal.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ICourseService _courseService;
    private readonly IStudentService _studentService;
    private readonly ITeacherService _teacherService;

    public HomeController(AppDbContext context, ICourseService courseService, IStudentService studentService, ITeacherService teacherService)
    {
        _context = context;
        _courseService = courseService;
        _studentService = studentService;
        _teacherService = teacherService;
    }

    public async Task<IActionResult> Index()
    {
        var courseCount = await _courseService.GetAllCoursesAsync();
        var studentCount = await _studentService.GetAllStudentsAsync();
        var teacherCount = await _teacherService.GetAllTeachersAsync();

        ViewBag.CourseCount = courseCount.Count();
        ViewBag.StudentCount = studentCount.Count();
        ViewBag.TeacherCount = teacherCount.Count();

        return View();
    }
}
