using WebAPI.BL.Models.Quiz;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Core;

namespace WebAPI.Modules.Quizzes.Features.GetQuiz;

public class GetQuizEndpoint : ApiEndpoint<GetQuizRequest, QuizQuestionsDto>
{
    private readonly IQuizService _quizService;

    public GetQuizEndpoint(IQuizService quizService)
    {
        _quizService = quizService;
    }

    public override void Configure()
    {
        Get("quizzes/{quizId}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Fetches the details of a specific quiz.";
            s.Description = "Returns the details of a specific quiz, including all associated questions.";
        });
    }

    public override async Task HandleAsync(GetQuizRequest req, CancellationToken ct)
    {
        var quiz = await _quizService.GetQuizAsync(req.QuizId, ct);

        if (quiz == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(quiz, ct);
    }
}
