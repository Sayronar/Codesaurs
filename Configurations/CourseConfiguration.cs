using Codesaurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codesaurs.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.ShortDescription).IsRequired();
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.Image).IsRequired();
        builder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(c => c.Duration).IsRequired();
        builder.Property(c => c.Level).IsRequired();
        builder.Property(c => c.Language).IsRequired();
        builder.Property(c => c.Chips).IsRequired();
        builder.Property(c => c.Views).IsRequired();
    }
}