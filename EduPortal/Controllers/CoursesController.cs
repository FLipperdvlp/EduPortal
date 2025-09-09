using System.ComponentModel.DataAnnotations;
using EduPortal.DataBase;
using EduPortal.Entities;
using EduPortal.Interface;
using EduPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("courses")]
public class CoursesController(ICourseService courseService) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await courseService.GetAllCoursesAsync();
        
        return View(courses.Select(c => new CourseViewModel
        {
            CourseId = c.CourseId,
            Title = c.Title,
            Description = c.Description,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            TeacherId = c.TeacherId
        }));
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
        return View(new Course());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCourse([FromForm] Course course)
    {
        if(!ModelState.IsValid) return View(course);
        
        await courseService.AddCourseAsync(course);

        return RedirectToAction("GetCourses");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> EditCourse(int id)
    {
        var course = await courseService.GetCourseByIdAsync(id);
        
        if(course == null) return NotFound();
        
        return View(course);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> EditCourse([FromForm] Course course)
    {
        if(!ModelState.IsValid) return View(course);
        
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