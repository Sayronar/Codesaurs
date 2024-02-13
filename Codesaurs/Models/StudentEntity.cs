namespace WebApplication4.Models;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public uint Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; }
    public string ProfileImageUrl { get; set; } = string.Empty;
    public string ParentFullName { get; set; }
    public string ParentContact { get; set; }
}