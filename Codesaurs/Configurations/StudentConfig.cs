using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication4.Models;

namespace WebApplication4.Configurations;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);
        builder.Property(student => student.FirstName).IsRequired();
        builder.Property(student => student.LastName).IsRequired();
        builder.Property(student => student.Email).IsRequired();
        builder.Property(student => student.Gender).IsRequired();
        builder.Property(student => student.BirthDate).IsRequired();
        builder.Property(student => student.ParentFullName).IsRequired();
        builder.Property(student => student.ParentContact).IsRequired();
    }
}