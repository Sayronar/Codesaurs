using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using WebApplication4.Models;
using WebApplication4.Repositories.Abstractions;

namespace WebApplication4.Repositories.Concretes;

public class StudentRepository : IStudentRepository
{
    private readonly CodesaurusDbContext _context;

    public StudentRepository(CodesaurusDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> Get()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student?> GetById(Guid id)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(student => student.Id == id);
    }

    public async Task<List<Student>> GetByName(string name)
    {
        return await _context.Students
            .AsNoTracking()
            .Where(student => (student.FirstName + student.LastName).Contains(name)).ToListAsync();
    }

    public async Task<Student?> GetByEmail(string email)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(student => student.Email == email);
    }

    public async Task Add(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string phoneNumber, string email, string profileImageUrl,
        string parentFullName, string parentContact)
    {
        var studentEntity = new Student(id, firstName, lastName, birthDate, gender, email, phoneNumber, profileImageUrl, parentFullName, parentContact);
        await _context.Students.AddAsync(studentEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        await _context.Students
            .Where(student => student.Id == id)
            .ExecuteDeleteAsync();
    }
    
    public async Task Update(Guid id, string firstName, string lastName, DateTime birthDate, string gender, string phoneNumber, string email,
        string profileImageUrl,
        string parentFullName, string parentContact)
    {
        if (!string.IsNullOrWhiteSpace(firstName))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.FirstName, student => firstName));
        }
        if (!string.IsNullOrWhiteSpace(lastName))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.LastName, student => lastName));
        }
        if (birthDate != null)
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.BirthDate, student => birthDate));
        }
        if (!string.IsNullOrWhiteSpace(gender))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.Gender, student => gender));
        }
        if (!string.IsNullOrWhiteSpace(email))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.Email, student => email));
        }
        if (!string.IsNullOrWhiteSpace(phoneNumber))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.PhoneNumber, student => phoneNumber));
        }
        if (!string.IsNullOrWhiteSpace(profileImageUrl))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.ProfileImageUrl, student => profileImageUrl));
        }
        if (!string.IsNullOrWhiteSpace(parentFullName))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.ParentFullName, student => parentFullName));
        }
        if (!string.IsNullOrWhiteSpace(parentContact))
        {
            await _context.Students
                .Where(student => student.Id == id)
                .ExecuteUpdateAsync(calls => calls
                    .SetProperty(student => student.ParentContact, parentContact));
        }
    }
    
    
}