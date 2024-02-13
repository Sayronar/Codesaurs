using Microsoft.EntityFrameworkCore;
using Codesaurs.Models;
using Codesaurs.Models;
using Codesaurs.Repositories;
using Codesaurs.Repositories.Abstraction;
using WebApplication4.DB;

namespace Codesaurs.Repository.Concrete;

public class CourseRepository : ICourseRepository
{
    private readonly CodesaurusDbContext _context;

    public CourseRepository(CodesaurusDbContext context)
    {
        _context = context;
    }

    public async Task<Course> GetCourseByIdAsync(Guid courseId)
    {
        var course = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == courseId);
    
        // Если курс найден, увеличиваем счетчик просмотров
        if (course != null)
        {
            course.Views++; // Увеличиваем счетчик просмотров
            await _context.SaveChangesAsync(); // Сохраняем изменения в базе данных
        }

        return course; 
    }

    public async Task<List<Course>> GetCoursesAsync(string sortBy, string language, int amount, string difficulty, decimal? duration, decimal? minPrice, decimal? maxPrice)
    {
        var query = _context.Courses.AsNoTracking();

        // Применяем фильтры
        if (!string.IsNullOrWhiteSpace(language))
            query = query.Where(c => c.Language == language);

        if (!string.IsNullOrWhiteSpace(difficulty))
            query = query.Where(c => c.Level == difficulty);

        if (duration.HasValue)
            query = query.Where(c => c.Duration == duration);

        if (minPrice.HasValue)
            query = query.Where(c => c.Price >= minPrice);

        if (maxPrice.HasValue)
            query = query.Where(c => c.Price <= maxPrice);

        // Применяем сортировку
        switch (sortBy)
        {
            case "name":
                query = query.OrderBy(c => c.Name);
                break;
            case "views":
                query = query.OrderByDescending(c => c.Views);
                break;
            case "price":
                query = query.OrderBy(c => c.Price);
                break;
            default:
                break;
        }

        // Получаем указанное количество курсов
        var courses = await query.Take(amount).ToListAsync();

        return courses;
    }

    public async Task<Guid> AddCourseAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return (Guid)course.Id;
    }

    public async Task AddViewAsync(Guid courseId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        if (course != null)
        {
            course.Views++;
            await _context.SaveChangesAsync();
        }
    }
}
