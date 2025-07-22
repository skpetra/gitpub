using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Modules.Quizzes.Features.ExportQuiz;

public record ExportQuizRequest([FromRoute] int QuizId)
{
    public required string Format { get; set; }
}
