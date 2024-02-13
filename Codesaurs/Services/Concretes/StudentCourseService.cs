using Codesaurs.Service.Abstractions;
using DefaultNamespace;
using WebApplication1.Models;

namespace WebApplication1.Services.Concretes;

public class StudentCourseService : IStudentCourseService
{
    private readonly IStudentCourseRepository _studentCourseRepository;

    public StudentCourseService(IStudentCourseRepository studentCourseRepository)
    {
        _studentCourseRepository = studentCourseRepository;
    }

    public async Task EnrollStudentInCourse(int studentId, int courseId)
    {
        var studentCourse = new StudentCourse
        {
            StudentId = studentId,
            CourseId = courseId,
            StartDate = DateTime.Now
        };

        await _studentCourseRepository.Add(studentCourse);
    }

    public async Task AddAttendance(int studentId, int courseId)
    {
        var attendance = new Attendance
        {
            StudentId = studentId,
            CourseId = courseId,
            VisitDate = DateTime.Now
        };
        
        await _studentCourseRepository.AddAttendance(attendance);
    }

    public async Task<StudentCourseProgress> GetStudentCourseProgress(int studentId, int courseId)
    {
        var studentCourse = await _studentCourseRepository.GetByStudentAndCourseId(studentId, courseId);

        if (studentCourse == null)
        {
            return null;
        }

        var progress = new StudentCourseProgress
        {
            Name = studentCourse.Course.Name,
            Image = studentCourse.Course.Image,
            MaxScore = studentCourse.Course.MaxScore ?? 0,
            StartDate = studentCourse.StartDate ?? DateTime.MinValue, 
            Progress = studentCourse.Progress ?? 0, 
            Score = studentCourse.Score ?? 0 
        };

        return progress;
    }
}