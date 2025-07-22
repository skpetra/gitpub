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
        var csv = new StringBuilder();
        csv.AppendLine($"{nameof(Question.Text)},{nameof(Question.Answer)}");

        foreach (var question in quiz.Questions)
        {
            csv.AppendLine($"{question.Text},{question.Answer}");
        }

        var csvContent = csv.ToString();
        return Encoding.UTF8.GetBytes(csvContent);
    }
}
