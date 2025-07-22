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
            .UsingEntity(j =>
            {
                j.ToTable("QuizQuestions");
                j.HasData(
                    new { QuizzesId = 1, QuestionsId = 1 },
                    new { QuizzesId = 1, QuestionsId = 2 },
                    new { QuizzesId = 1, QuestionsId = 3 },
                    new { QuizzesId = 1, QuestionsId = 4 },
                    new { QuizzesId = 1, QuestionsId = 5 },
                    new { QuizzesId = 1, QuestionsId = 6 },
                    new { QuizzesId = 1, QuestionsId = 7 },
                    new { QuizzesId = 1, QuestionsId = 8 },
                    new { QuizzesId = 1, QuestionsId = 9 },
                    new { QuizzesId = 1, QuestionsId = 10 },
                    new { QuizzesId = 1, QuestionsId = 11 },
                    new { QuizzesId = 1, QuestionsId = 12 },
                    new { QuizzesId = 1, QuestionsId = 13 },
                    new { QuizzesId = 1, QuestionsId = 14 },
                    new { QuizzesId = 1, QuestionsId = 15 },
                    new { QuizzesId = 1, QuestionsId = 16 },
                    new { QuizzesId = 1, QuestionsId = 17 },
                    new { QuizzesId = 1, QuestionsId = 18 },
                    new { QuizzesId = 1, QuestionsId = 19 },
                    new { QuizzesId = 1, QuestionsId = 20 },
                    new { QuizzesId = 2, QuestionsId = 12 },
                    new { QuizzesId = 2, QuestionsId = 13 },
                    new { QuizzesId = 2, QuestionsId = 14 },
                    new { QuizzesId = 2, QuestionsId = 15 },
                    new { QuizzesId = 2, QuestionsId = 16 },
                    new { QuizzesId = 2, QuestionsId = 17 },
                    new { QuizzesId = 2, QuestionsId = 18 },
                    new { QuizzesId = 2, QuestionsId = 19 },
                    new { QuizzesId = 2, QuestionsId = 20 },
                    new { QuizzesId = 2, QuestionsId = 21 }
                );
            });
    }
}
