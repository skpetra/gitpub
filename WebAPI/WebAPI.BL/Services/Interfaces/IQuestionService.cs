using WebAPI.DAL.Models;

namespace WebAPI.BL.Services.Interfaces;

public interface IQuestionService
{
    Task<bool> DoAllQuestionsExistAsync(int[] questionIds, CancellationToken ct = default);
    Task<IEnumerable<Question>> GetQuestionsByIdsAsync(int[] questionIds, CancellationToken ct = default);
    Task<bool> DoesQuestionExistByTextAsync(string text, CancellationToken ct = default);
    Task<bool> DoesQuestionExistByIdAsync(int id, CancellationToken ct = default);
}
