using CourseBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Codesaurs.Models;

namespace CourseBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/courses")]
        public IActionResult GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            var result = new
            {
                Courses = courses,
                Count = courses.Count
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return Ok(course);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(string id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            course.Views++;
            _context.SaveChanges();

            return Ok(course);
        }

        [HttpGet("/courses/sorted")]
        public IActionResult SortedCourses(string sortBy = "", string language = "", int amount = 10)
        {
            var filteredCourses = _context.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(language))
                filteredCourses = filteredCourses.Where(c => c.Language!.ToLower() == language);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "views":
                        filteredCourses = filteredCourses.OrderByDescending(c => c.Views);
                        break;
                }
            }

            var count = filteredCourses.Count();
            var limitedCourses = filteredCourses.Take(amount).ToList();

            var result = new
            {
                Courses = limitedCourses,
                Count = count
            };

            return Ok(result);
        }
        
        [HttpGet("/courses/search")]
        public IActionResult SearchCourses(string query)
        {
            var courses = _context.Courses.Where(c => c.Name!.Contains(query)).ToList();
            var result = new
            {
                Courses = courses,
                Count = courses.Count
            };
            return Ok(result);
        }
    }
}
