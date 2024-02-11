using Microsoft.AspNetCore.Mvc;
using WebApplication4.Contracts;
using WebApplication4.Models;
using WebApplication4.Services;
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

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAll();
        return View(students);
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var student = _studentService.GetById(id);
        return student == null ? NotFound() : View(student);
    }

    [HttpPost]
    public void Add([FromBody] StudentsRequest request)
    {
        var student = new Student(Guid.NewGuid(), request.FirstName, request.LastName, request.BirthDate, request.Gender, request.Email, request.PhoneNumber,
            request.ProfileImageUrl, request.ParentFullName, request.ParentContact);
        _studentService.Add(student);
    }

    [HttpDelete]
    public void Delete(Guid id)
    {
        _studentService.Delete(id);
    }
    
    [HttpPut]
    public void Update([FromBody] StudentsResponse response)
    {
        _studentService.Update(response.Id, response.FirstName, response.LastName, response.BirthDate, response.Age, response.Gender, response.PhoneNumber, response.Email,
            response.ProfileImageUrl, response.ParentFullName, response.ParentContact);
    }
    
    [HttpPut]
    public async void UpdateFirstName(Guid id, string firstName)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, firstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }

    [HttpPut]
    public async void UpdateLastName(Guid id, string lastName)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, lastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }

    [HttpPut]
    public async void UpdateBirthDate(Guid id, DateTime birthDate)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, birthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }

    [HttpPut]
    public async void UpdateGender(Guid id, string gender)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }

    [HttpPut]
    public async void UpdatePhoneNumber(Guid id, string phoneNumber)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, phoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }
    
    [HttpPut]
    public async void UpdateEmail(Guid id, string email)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, email,
                student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }
    
    [HttpPut]
    public async void UpdateProfileImage(Guid id, string profileImageUrl)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                profileImageUrl, student.ParentFullName, student.ParentContact);
        }
    }
    
    [HttpPut]
    public async void UpdateParentFullName(Guid id, string parentFullName)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, parentFullName, student.ParentContact);
        }
    }
    
    [HttpPut]
    public async void UpdateParentContact(Guid id, string parentContact)
    {
        var student = await _studentService.GetById(id);
        if (student != null)
        {
            await _studentService.Update(id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
                student.ProfileImageUrl, student.ParentFullName, parentContact);
        }
    }

}