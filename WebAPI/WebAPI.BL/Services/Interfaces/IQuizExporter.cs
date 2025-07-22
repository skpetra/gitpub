using WebAPI.BL.Models.Quiz;

namespace WebAPI.BL.Services.Interfaces;

public interface IQuizExporter
{
    string Format { get; }
    string ContentType { get; }
    Task<byte[]> ExportAsync(QuizQuestionsDto quiz, CancellationToken ct = default);
}
