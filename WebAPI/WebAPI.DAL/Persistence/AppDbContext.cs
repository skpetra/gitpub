using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.DAL.Models;

namespace WebAPI.DAL.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Quiz>()
            .HasMany(e => e.Questions)
            .WithMany(e => e.Quizzes)
            .UsingEntity(j => j.ToTable("QuizQuestions"));
    }
}
