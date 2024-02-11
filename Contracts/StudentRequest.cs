namespace WebApplication4.Contracts;

public record StudentsRequest(string FirstName, string LastName, DateTime BirthDate, uint Age, string Gender, string Email, string PhoneNumber, string ProfileImageUrl,
    string ParentFullName,
    string ParentContact);