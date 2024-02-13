using DefaultNamespace;

namespace WebApplication4.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public uint Age { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; }
    public string ProfileImageUrl { get; set; } = string.Empty;
    public string ParentFullName { get; set; }
    public string ParentContact { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public Student(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string email, string phoneNumber, string profileImageUrl,
        string parentFullName,
        string parentContact)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        var temp = BirthDate.Year - DateTime.Today.Year;
        Age = (uint)(BirthDate.AddYears(temp) <= DateTime.Today ? temp : temp - 1);
        Gender = gender;
        Email = email;
        ProfileImageUrl = profileImageUrl;
        PhoneNumber = phoneNumber;
        ParentFullName = parentFullName;
        ParentContact = parentContact;
    }
}