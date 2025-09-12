using System.ComponentModel.DataAnnotations;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.AspNetCore.Mvc;
using EduPortal.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduPortal.Controllers;

[Route("Enrollment")]
public class EnrollmentsController(IEnrollmentService IenrollmentService, AppDbContext ctx) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetEnrollments()
    {
        var enrollments = await IenrollmentService.GetAllEnrollmentsAsync();
        
        return View(/*enrollments*/);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details([Required] int id)
    {
        var enrollment = await IenrollmentService.GetEnrollmentByIdAsync(id);
        
        if(enrollment == null) return NotFound();
        
        return View(enrollment);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(ctx.Courses.AsNoTracking().ToList(), "CourseId", "Title");
        ViewBag.Students = new SelectList(ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToList(), "StudentId", "Name");
        return View(new Enrollment());
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] Enrollment enrollment)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("ENROLLMENT NOT ADDED 1");
            ViewBag.Courses = new SelectList(await ctx.Courses.AsNoTracking().ToListAsync(), "CourseId", "Title");
            ViewBag.Students = new SelectList(await ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToListAsync(), "StudentId", "Name");
            return View(enrollment);
        }

        var courseExists = await ctx.Courses.AnyAsync(c => c.CourseId == enrollment.CourseId);
        if (!courseExists)
        {
            ModelState.AddModelError("CourseId", "Вказаний курс не існує.");
        }

        var studentExists = await ctx.Students.AnyAsync(s => s.StudentId == enrollment.StudentId);
        if (!studentExists)
        {
            ModelState.AddModelError("StudentId", "Вказаний студент не існує.");
        }

        if (!ModelState.IsValid)
        {
            Console.WriteLine("ENROLLMENT NOT ADDED 2");
            ViewBag.Courses = new SelectList(await ctx.Courses.AsNoTracking().ToListAsync(), "CourseId", "Title");
            ViewBag.Students = new SelectList(await ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToListAsync(), "StudentId", "Name");
            return View(enrollment);
        }

        await IenrollmentService.AddEnrollmentAsync(enrollment);
        Console.WriteLine("ENROLLMENT ADDED");

        return RedirectToAction("GetEnrollments");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var enrollment = await IenrollmentService.GetEnrollmentByIdAsync(id);
        
        if(enrollment == null) return NotFound();
        ViewBag.Courses = new SelectList(await ctx.Courses.AsNoTracking().ToListAsync(), "CourseId", "Title", enrollment.CourseId);
        ViewBag.Students = new SelectList(await ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToListAsync(), "StudentId", "Name", enrollment.StudentId);
        return View(enrollment);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> Edit([FromForm] Enrollment enrollment)
    {
        if(!ModelState.IsValid)
        {
            ViewBag.Courses = new SelectList(await ctx.Courses.AsNoTracking().ToListAsync(), "CourseId", "Title", enrollment.CourseId);
            ViewBag.Students = new SelectList(await ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToListAsync(), "StudentId", "Name", enrollment.StudentId);
            return View(enrollment);
        }

        var courseExists = await ctx.Courses.AnyAsync(c => c.CourseId == enrollment.CourseId);
        if (!courseExists)
        {
            ModelState.AddModelError("CourseId", "Вказаний курс не існує.");
        }

        var studentExists = await ctx.Students.AnyAsync(s => s.StudentId == enrollment.StudentId);
        if (!studentExists)
        {
            ModelState.AddModelError("StudentId", "Вказаний студент не існує.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Courses = new SelectList(await ctx.Courses.AsNoTracking().ToListAsync(), "CourseId", "Title", enrollment.CourseId);
            ViewBag.Students = new SelectList(await ctx.Students.AsNoTracking().Select(s => new { s.StudentId, Name = s.FirstName + " " + s.LastName }).ToListAsync(), "StudentId", "Name", enrollment.StudentId);
            return View(enrollment);
        }
        
        await IenrollmentService.UpdateEnrollmentAsync(enrollment);
        
        return RedirectToAction("GetEnrollments");
    }

    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var enrollment = await IenrollmentService.GetEnrollmentByIdAsync(id);
        
        if(enrollment == null) return NotFound();
        
        return View(enrollment);
    }

    [HttpPost("delete/{id:int}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await IenrollmentService.DeleteEnrollmentAsync(id);
        
        return RedirectToAction("GetEnrollments");
    }
}