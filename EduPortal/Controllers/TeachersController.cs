using EduPortal.Entities;
using EduPortal.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("teachers")]
public class TeachersController(ITeacherService  teacherService) : Controller
{
    [HttpGet("Get")]
    public async Task<IActionResult> GetTeachers()
    {
        var teachers = teacherService.GetAllTeachersAsync();
        
        return View(teachers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var teacher = await teacherService.GetTeacherByIdAsync(id);
        
        if(teacher == null) return NotFound();
        
        return View(teacher);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new Teacher());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] Teacher teacher)
    {
        if(!ModelState.IsValid) return View(teacher);
        
        await teacherService.AddTeacherAsync(teacher);

        return RedirectToAction("GetTeachers");
    }

    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var teacher = await teacherService.GetTeacherByIdAsync(id);
        
        if(teacher == null) return NotFound();
        
        return View(teacher);
    }
    
    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> Edit([FromForm] Teacher teacher)
    {
        if(!ModelState.IsValid) return View(teacher);
        
        await teacherService.UpdateTeacherAsync(teacher);
        
        return RedirectToAction("GetTeachers");
    }

    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var teacher = await teacherService.GetTeacherByIdAsync(id);
        
        if(teacher == null) return NotFound();
        
        return View(teacher);
    }

    [HttpPost("delete/{id:int}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await teacherService.DeleteTeacherAsync(id);
        
        return RedirectToAction("GetTeachers");
    }
}