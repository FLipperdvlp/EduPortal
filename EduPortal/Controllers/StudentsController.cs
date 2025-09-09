using System.ComponentModel.DataAnnotations;
using EduPortal.Entities;
using EduPortal.Interface;
using EduPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("students")]
public class StudentsController(IStudentService IstudentService) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetStudents()
    {
        var students = await IstudentService.GetAllStudentsAsync();
        
        return View(students.Select(s => new StudentViewModel
        {
            StudentId = s.StudentId,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            DateOfBirth = s.DateOfBirth
        }));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var student = await IstudentService.GetStudentByIdAsync(id);
        
        if(student == null) return NotFound();
        
        return View(student);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new Student());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([Required] Student student)
    {
        if(!ModelState.IsValid) return View(student);
        
        await IstudentService.AddStudentAsync(student);
        
        return RedirectToAction("GetStudents");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await IstudentService.GetStudentByIdAsync(id);

        if (student == null) return NotFound();

        return View(student);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> Edit([FromForm] Student student)
    {
        if(!ModelState.IsValid) return View(student);
        
        await IstudentService.UpdateStudentAsync(student);
        
        return RedirectToAction("GetStudents");
    }

    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await IstudentService.GetStudentByIdAsync(id);
        
        if(student == null) return NotFound();
        
        return View(student);
    }

    [HttpPost("delete/{id:int}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await IstudentService.DeleteStudentAsync(id);
        
        return RedirectToAction("GetStudents");
    }
}