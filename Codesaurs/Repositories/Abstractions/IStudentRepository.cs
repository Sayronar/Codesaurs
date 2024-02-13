using WebApplication4.Models;

namespace WebApplication4.Repositories.Abstractions;

public interface IStudentRepository
{
    public Task<List<Student>> Get();
    public Task<Student?> GetById(Guid id);
    public Task<List<Student>> GetByName(string name);
    public Task<Student?> GetByEmail(string email);
    public Task Add(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string phoneNumber, string email, string profileImageUrl,
        string parentFullName, string parentContact);
    public Task Update(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string phoneNumber, string email,
        string profileImageUrl,
        string parentFullName, string parentContact);
    public Task Delete(Guid id);
}