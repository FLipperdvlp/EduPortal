using System.ComponentModel.DataAnnotations;
using EduPortal.Entities;
using EduPortal.Interface;
using EduPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers;

[Route("students")]
public class StudentsController(IStudentService IstudentService) : Controller
{
    [HttpGet("get")]
    public async Task<IActionResult> GetStudents()
    {
        var students = await IstudentService.GetAllStudentsAsync();

        foreach(var s in students)
        {
            Console.WriteLine($"DB Student: FirstName={s.FirstName}, LastName={s.LastName}, Email={s.Email}, Phone={s.PhoneNumber}, DOB={s.DateOfBirth}");
        }

        var model = students.Select(s => new StudentViewModel
        {
            StudentId = s.StudentId,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            DateOfBirth = s.DateOfBirth
        });

        return View(model);
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
        return View(new StudentViewModel());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateStudent(StudentViewModel vm)
    {
        Console.WriteLine("🚀 CreateStudent POST called");

        // Выведем все данные из ViewModel перед проверкой
        Console.WriteLine($"ViewModel: FirstName={vm.FirstName}, LastName={vm.LastName}, Email={vm.Email}, Phone={vm.PhoneNumber}, DOB={vm.DateOfBirth}");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("❌ ModelState is invalid");
            return View(vm);
        }

        // Преобразуем ViewModel в Entity
        var studentEntity = new Student
        {
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            Email = vm.Email,
            PhoneNumber = vm.PhoneNumber,
            DateOfBirth = vm.DateOfBirth
        };

        // Выведем перед добавлением в БД
        Console.WriteLine($"Student Entity to add: FirstName={studentEntity.FirstName}, LastName={studentEntity.LastName}, Email={studentEntity.Email}, Phone={studentEntity.PhoneNumber}, DOB={studentEntity.DateOfBirth}");

        await IstudentService.AddStudentAsync(studentEntity);

        Console.WriteLine("✅ Student created and saved to DB");

        return RedirectToAction("GetStudents");
    }




    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await IstudentService.GetStudentByIdAsync(id);
        if (student == null) return NotFound();

        // Entity → ViewModel
        var model = new StudentViewModel
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
            DateOfBirth = student.DateOfBirth
        };

        return View(model);
    }

    [HttpPost("edit/{id:int}")]
    public async Task<IActionResult> Edit(StudentViewModel studentViewModel)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("❌ Помилка: Дані некоректні");
            return View(studentViewModel);
        }

        var student = new Student
        {
            StudentId = studentViewModel.StudentId,
            FirstName = studentViewModel.FirstName,
            LastName = studentViewModel.LastName,
            Email = studentViewModel.Email,
            PhoneNumber = studentViewModel.PhoneNumber,
            DateOfBirth = studentViewModel.DateOfBirth
        };

        await IstudentService.UpdateStudentAsync(student);
        
        Console.WriteLine(student.FirstName);
        Console.WriteLine("✅ Student updated");

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