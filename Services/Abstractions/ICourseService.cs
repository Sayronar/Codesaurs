using Codesaurs.Models;

namespace Codesaurs.Service.Abstractions;

public interface ICourseService
{
    public Task<List<Course>> GetAllCourses();
    public Task<Course> GetCourseByIdAsync(Guid courseId);
    public Task<Guid> AddCourseAsync(Course course);
    public Task<List<Course>> GetCoursesAsync(string sortBy, string language, int amount, string difficulty, decimal? duration, decimal? minPrice, decimal? maxPrice);
}