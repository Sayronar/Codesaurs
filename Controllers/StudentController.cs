using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services.Abstractions;

namespace WebApplication4.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IActionResult Home()
    {
        return View();
    }

    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAll();
        return View("GetAll", students);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        return View("GetById",student);
    }

    [HttpPost]
    public IActionResult Add(string firstName, string lastName, DateTime birthDate, string gender, string email, string phoneNumber, string profileImageUrl,
        string parentFullName,
        string parentContact)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var student = new Student(Guid.NewGuid(), firstName, lastName, birthDate, gender, email, phoneNumber, profileImageUrl, parentFullName, parentContact);
        _studentService.Add(student);

        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }
    
    [HttpPut]
    public void Update([FromBody] Student student)
    {
        _studentService.Update(student.Id, student.FirstName, student.LastName, student.BirthDate, student.Gender, student.PhoneNumber, student.Email,
            student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
    }
    
    [HttpDelete]
    public void Delete(Guid id)
    {
        _studentService.Delete(id);
    }

}