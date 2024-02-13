using WebApplication4.Models;
using WebApplication4.Repositories.Abstractions;
using WebApplication4.Services.Abstractions;

namespace WebApplication4.Services.Concretes;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> GetAll()
    {
        var studentEntities = await _studentRepository.Get();
        var students = studentEntities.Select(student => new Student(
            student.Id, student.FirstName, student.LastName, student.BirthDate, student.Gender, student.Email, student.PhoneNumber, student.ProfileImageUrl,
            student.ParentFullName, student.ParentContact)).ToList();
        return students.ToList();
    }

    public async Task<Student?> GetById(Guid id)
    {
        var studentEntity = await _studentRepository.GetById(id);
        if (studentEntity == null) return null;
        var student = new Student(studentEntity.Id, studentEntity.FirstName, studentEntity.LastName, studentEntity.BirthDate, studentEntity.Gender, studentEntity.Email,
            studentEntity.PhoneNumber, studentEntity.ProfileImageUrl, studentEntity.ParentFullName, studentEntity.ParentContact);
        return student;
    }

    public async Task<Student> GetByEmail(String email)
    {
        var studentEntity = await _studentRepository.GetByEmail(email);
        var student = new Student(studentEntity.Id, studentEntity.FirstName, studentEntity.LastName, studentEntity.BirthDate, studentEntity.Gender, studentEntity.Email,
            studentEntity.PhoneNumber, studentEntity.ProfileImageUrl, studentEntity.ParentFullName, studentEntity.ParentContact);
        return student;
    }

    public async Task Add(Student student)
    {
        await _studentRepository.Add(student.Id, student.FirstName, student.LastName, student.BirthDate, student.Age, student.Gender, student.PhoneNumber, student.Email,
            student.ProfileImageUrl, student.ParentFullName, student.ParentContact);
    }

    public async Task Update(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string phoneNumber, string email,
        string profileImageUrl,
        string parentFullName, string parentContact)
    {
        await _studentRepository.Update(id, firstName, lastName, birthDate, gender, phoneNumber, email, profileImageUrl, parentFullName, parentContact);
    }

    public async Task Delete(Guid id)
    {
        await _studentRepository.Delete(id);
    }


}