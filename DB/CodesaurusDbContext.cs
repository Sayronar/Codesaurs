using Microsoft.EntityFrameworkCore;
using WebApplication4.Configurations;
using WebApplication4.Models;

namespace WebApplication4.DB;

public class CodesaurusDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    public CodesaurusDbContext(DbContextOptions<CodesaurusDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfig());
        base.OnModelCreating(modelBuilder);
    }
}