using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication4.DB;

namespace WebApplication1.Repositories.Concretes;

public class StudentCourseRepository : IStudentCourseRepository
{
    private readonly CodesaurusDbContext _context;

    public StudentCourseRepository(CodesaurusDbContext context)
    {
        _context = context;
    }

    public async Task<StudentCourse> GetById(int id)
    {
        return await _context.StudentCourses.FindAsync(id);
    }

    public async Task<IEnumerable<StudentCourse>> GetAll()
    {
        return await _context.StudentCourses.ToListAsync();
    }

    public async Task Add(StudentCourse studentCourse)
    {
        await _context.StudentCourses.AddAsync(studentCourse);
        await _context.SaveChangesAsync();
    }

    public async Task Update(StudentCourse studentCourse)
    {
        _context.Entry(studentCourse).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var studentCourse = await _context.StudentCourses.FindAsync(id);
        if (studentCourse != null)
        {
            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddAttendance(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task<StudentCourse> GetByStudentAndCourseId(int studentId, int courseId)
    {
        return await _context.StudentCourses.FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
    }
}