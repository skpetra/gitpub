using System.Composition;
using System.Text;
using WebAPI.BL.Models.Quiz;
using WebAPI.BL.Services.Interfaces;
using WebAPI.DAL.Models;

namespace WebAPI.BL.Services;

[Export(typeof(IQuizExporter))]
public class ExportToCsvService : IQuizExporter
{
    public string Format => "csv";
    public string ContentType => "text/csv";

    public async Task<byte[]> ExportAsync(QuizQuestionsDto quiz, CancellationToken ct = default)
    {
        await using var memoryStream = new MemoryStream();
        await using var writer = new StreamWriter(memoryStream, Encoding.UTF8);

        await writer.WriteLineAsync($"{nameof(Question.Text)},{nameof(Question.Answer)}");

        foreach (var question in quiz.Questions)
        {
            await writer.WriteLineAsync($"{question.Text},{question.Answer}");
        }

        await writer.FlushAsync(ct);

        return memoryStream.ToArray();
    }
}
