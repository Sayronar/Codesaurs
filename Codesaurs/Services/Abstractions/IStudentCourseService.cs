using WebApplication1.Models;

namespace Codesaurs.Service.Abstractions;

public interface IStudentCourseService
{
    Task EnrollStudentInCourse(int studentId, int courseId);
    Task AddAttendance(int studentId, int courseId);
    Task<StudentCourseProgress> GetStudentCourseProgress(int studentId, int courseId);
}