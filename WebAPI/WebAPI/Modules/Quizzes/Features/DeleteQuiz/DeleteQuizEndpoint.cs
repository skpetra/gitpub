using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core;

namespace WebAPI.Modules.Quizzes.Features.DeleteQuiz;

public class DeleteQuizEndpoint : ApiEndpoint<DeleteQuizRequest, EmptyResponse>
{
    private readonly ILogger<DeleteQuizEndpoint> _logger;

    public DeleteQuizEndpoint(ILogger<DeleteQuizEndpoint> logger)
    {
        _logger = logger;
    }

    public override void Configure()
    {
        Delete("quizzes/{quizId}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Deletes a specific quiz.";
            s.Description = "Deletes a quiz by its ID. The quiz will be removed and no longer appear in quiz listings, " +
                "but its associated questions will remain in the system for future reuse.";
        });
    }
    public override async Task HandleAsync(DeleteQuizRequest req, CancellationToken ct)
    {
        var quiz = await Context.Quizzes
            .Where(q => q.Id == req.QuizId)
            .FirstOrDefaultAsync(ct);

        if (quiz is null)
        {
            _logger.LogWarning("Quiz with id '{QuizId}' not found.", req.QuizId);
            await SendNotFoundAsync(ct);
            return;
        }

        Context.Quizzes.Remove(quiz);
        await Context.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}

