using System.ComponentModel.DataAnnotations;
using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using EduPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("Course")]
public class CoursesController(ICourseService courseService) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await courseService.GetAllCoursesAsync();
        
        var model = courses
            .Where(c => c != null)
            .Select(c => new CourseViewModel
            {
                Title = c!.Title,
                Description = c.Description,
                Category = c.Category,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                TeacherId = c.TeacherId,
                TeacherName = c.TeacherName
            }).ToList();

        return View(model);

    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details([Required] int id)
    {
        var courses = await courseService.GetCourseByIdAsync(id);
        
        if(courses == null) return NotFound();
        
        return View(courses);
    }

    [HttpGet("create")]
    public IActionResult CreateCourse()
    {
        return View(new CourseViewModel());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCourse([FromForm] Course course)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Course not added");
            return View(course);
        }
        
        await courseService.AddCourseAsync(course);
        Console.WriteLine("Course added");
        
        return RedirectToAction("GetCourses");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> EditCourse(int id)
    {
        var course = await courseService.GetCourseByIdAsync(id);
        
        if(course == null) return NotFound();
        
        var model = new CourseViewModel
        {
            CourseId = course.CourseId,
            Title = course.Title,
            Description = course.Description,
            Category = course.Category,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            TeacherId = course.TeacherId,
            TeacherName = course.TeacherName
        };

        return View(model);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> EditCourse(CourseViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);

        var course = new Course
        {
            CourseId = model.CourseId,
            Title = model.Title,
            Description = model.Description,
            Category = model.Category,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            TeacherId = model.TeacherId,
            TeacherName = model.TeacherName
        };

        await courseService.UpdateCourseAsync(course);
        return RedirectToAction("GetCourses");
    }

    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await courseService.GetCourseByIdAsync(id);
        
        if(course == null) return NotFound();

        return View(course);
    }

    [HttpPost("delete/{id:int}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await courseService.DeleteCourseByIdAsync(id);
        
        return RedirectToAction("GetCourses");
    }
}