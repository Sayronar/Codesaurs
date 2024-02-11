using WebApplication4.Models;

namespace WebApplication4.Repositories.Abstractions;

public interface IStudentRepository
{
    public Task<List<StudentEntity>> Get();
    public Task<StudentEntity?> GetById(Guid id);
    public Task<List<StudentEntity>> GetByName(string name);
    public Task<StudentEntity?> GetByEmail(string email);
    public Task Add(Guid id, string firstName, string lastName, DateTime birthDate, uint age, string gender, string phoneNumber, string email, string profileImageUrl,
        string parentFullName, string parentContact);
    public Task Update(Guid id, string firstName, string lastName, DateTime birthDate, uint age, string gender, string phoneNumber, string email,
        string profileImageUrl,
        string parentFullName, string parentContact);
    public Task Delete(Guid id);
}