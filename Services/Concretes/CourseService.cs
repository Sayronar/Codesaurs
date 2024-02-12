using Codesaurs.Models;
using Codesaurs.Repositories.Abstraction;
using Codesaurs.Repository.Concrete;
using Codesaurs.Service.Abstractions;

namespace Codesaurs.Service.Concretes
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.GetCoursesAsync("name", null, int.MaxValue, null, null, null, null);
        }

        public async Task<List<Course>> GetCoursesAsync(string sortBy, string language, int amount, string difficulty,
            decimal? duration,
            decimal? minPrice, decimal? maxPrice)
        {
            return await _courseRepository.GetCoursesAsync(sortBy, language, amount, difficulty, duration, minPrice,
                maxPrice);
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _courseRepository.GetCourseByIdAsync(courseId);
        }

        public async Task<Guid> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddCourseAsync(course);
        }
    }
}