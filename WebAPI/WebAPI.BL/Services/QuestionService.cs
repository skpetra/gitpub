using Microsoft.EntityFrameworkCore;
using WebAPI.BL.Services.Interfaces;
using WebAPI.DAL.Models;
using WebAPI.DAL.Persistence;

namespace WebAPI.BL.Services;

public class QuestionService : IQuestionService
{
    public readonly AppDbContext _context;

    public QuestionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DoAllQuestionsExistAsync(int[] questionIds, CancellationToken ct = default)
    {
        var existingQuestionIds = await _context.Questions
            .AsNoTracking()
            .Where(q => questionIds.Contains(q.Id))
            .Select(q => q.Id)
            .ToListAsync(ct);

        return existingQuestionIds.Count == questionIds.Length;
    }

    public async Task<List<Question>> GetQuestionsByIdsAsync(int[] questionIds, CancellationToken ct = default)
    {
        return await _context.Questions
            .Where(q => questionIds.Contains(q.Id))
            .ToListAsync(ct);
    }
}
