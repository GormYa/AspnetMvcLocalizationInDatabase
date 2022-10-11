using LocalizationInDatabase.Mvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LocalizationInDatabase.Mvc.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<StringResource> StringResources { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
