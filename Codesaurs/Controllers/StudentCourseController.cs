using Codesaurs.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class StudentCourseController : Controller
{
    private readonly IStudentCourseService _studentCourseService;

    public StudentCourseController(IStudentCourseService studentCourseService)
    {
        _studentCourseService = studentCourseService;
    }

    [HttpPost("enroll")]
    public async Task<IActionResult> EnrollStudentInCourse(int studentId, int courseId)
    {
        await _studentCourseService.EnrollStudentInCourse(studentId, courseId);
        return RedirectToAction("Index", "Home"); 
    }

    [HttpPost("attendance")]
    public async Task<IActionResult> AddAttendance(int studentId, int courseId)
    {
        await _studentCourseService.AddAttendance(studentId, courseId);
        return RedirectToAction("Index", "Home"); 
    }

    [HttpGet("progress")]
    public async Task<IActionResult> GetStudentCourseProgress(int studentId, int courseId)
    {
        var progress = await _studentCourseService.GetStudentCourseProgress(studentId, courseId);
        if (progress == null)
        {
            return NotFound(); 
        }
        return View("Progress", progress); 
    }
}