using Codesaurs.Models;
using WebApplication4.Models;

namespace DefaultNamespace;

public class StudentCourse
{
    public int? Id { get; set; } 
    public int? StudentId { get; set; } 
    public int? CourseId { get; set; } 
    public DateTime? StartDate { get; set; } 
    public int? Progress { get; set; } 
    public int? Score { get; set; } 
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}