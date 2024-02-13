namespace WebApplication4.Contracts;

public record StudentsResponse(Guid Id, string FirstName, string LastName, DateTime BirthDate, string Gender, string Email, string PhoneNumber,
    string ProfileImageUrl,
    string ParentFullName,
    string ParentContact);