using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using System.Reflection;

namespace Storage.Infrastructure.Data;

public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseResolve> ExercisesResolves { get; set; }
    public DbSet<TestCase> TestCases { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
