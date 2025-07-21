using Microsoft.EntityFrameworkCore;
using WebAPI.BL.Models.Quiz;
using WebAPI.BL.Services.Interfaces;
using WebAPI.DAL.Persistence;

namespace WebAPI.BL.Services;

public class QuizService : IQuizService
{
    public readonly AppDbContext _context;

    public QuizService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesNameExistAsync(string name, CancellationToken ct = default)
    {
        return await _context.Quizzes.AnyAsync(q => q.Name == name, ct);
    }

    public async Task<QuizQuestionsDto> GetQuizAsync(int id, CancellationToken ct = default)
    {
        var quiz = await _context.Quizzes
            .Include(q => q.Questions)
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id, ct);

        return QuizQuestionsDto.FromEntity(quiz);
    }
}
