using WebApplication4.Models;

namespace WebApplication4.Services.Abstractions;

public interface IStudentService
{
    public Task<List<Student>> GetAll();
    public Task<Student?> GetById(Guid id);
    public Task<Student> GetByEmail(String email);
    public Task Add(Student student);
    public Task Update(Guid id, string firstName, string lastName, DateTime birthDate, uint age, string gender, string phoneNumber, string email,
        string profileImageUrl,
        string parentFullName, string parentContact);
    public Task Delete(Guid id);
}