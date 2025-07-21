using WebAPI.BL.Models.Quiz;

namespace WebAPI.BL.Services.Interfaces;

public interface IQuizService
{
    Task<bool> DoesNameExistAsync(string name, CancellationToken ct = default);
    Task<QuizQuestionsDto> GetQuizAsync(int id, CancellationToken ct = default);
}
