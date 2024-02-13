using Microsoft.AspNetCore.Mvc;
using WebApplication4.Contracts;
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

    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }

    [HttpGet("/students")]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAll();
        return View("GetAll", students);
    }

    [HttpGet("/students/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        return View("GetById",student);
    }

    [HttpPost("/students/add")]
    public IActionResult Add([FromBody] StudentsRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var student = new Student(Guid.NewGuid(), request.FirstName, request.LastName, request.BirthDate, request.Gender, request.Email, request.PhoneNumber,
            request.ProfileImageUrl, request.ParentFullName, request.ParentContact);
        _studentService.Add(student);

        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }
    
    [HttpPut("/students/update")]
    public void Update([FromBody] StudentsResponse response)
    {
        _studentService.Update(response.Id, response.FirstName, response.LastName, response.BirthDate, response.Gender, response.PhoneNumber, response.Email,
            response.ProfileImageUrl, response.ParentFullName, response.ParentContact);
    }
    
    [HttpDelete("/students/delete")]
    public void Delete(Guid id)
    {
        _studentService.Delete(id);
    }

}