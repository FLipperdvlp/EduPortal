using System.ComponentModel.DataAnnotations;
using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("enrollments")]
public class EnrollmentsController(IEnrollmentService IenrollmentService) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetEnrollments()
    {
        var enrollments = await IenrollmentService.GetAllEnrollmentsAsync();
        
        return View(enrollments);
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
        return View(new Enrollment());
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] Enrollment enrollment)
    {
        if(!ModelState.IsValid) return View(enrollment);
        
        await IenrollmentService.AddEnrollmentAsync(enrollment);
        
        return RedirectToAction("GetEnrollments");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var enrollment = await IenrollmentService.GetEnrollmentByIdAsync(id);
        
        if(enrollment == null) return NotFound();
        
        return View(enrollment);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> Edit([FromForm] Enrollment enrollment)
    {
        if(!ModelState.IsValid) return View(enrollment);
        
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