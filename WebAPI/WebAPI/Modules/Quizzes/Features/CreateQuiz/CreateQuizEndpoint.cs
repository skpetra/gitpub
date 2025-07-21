using Mapster;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Core;
using WebAPI.Core.Models;
using WebAPI.DAL.Models;

namespace WebAPI.Modules.Quizzes.Features.CreateQuiz;

public class CreateQuizEndpoint : ApiEndpoint<BaseQuizRequest, CreateQuizResponse>
{
    private readonly IQuestionService _questionService;

    public CreateQuizEndpoint(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    public override void Configure()
    {
        Post("quizzes");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Creates a new quiz with support for question reuse.";
            s.Description = "Creates a new quiz by combining a list of newly created questions and references to existing questions by their IDs. " +
                "The final quiz will include both newly created and previously existing questions.";
        });
    }

    public override async Task HandleAsync(BaseQuizRequest req, CancellationToken ct)
    {
        var newQuestions = req.NewQuestions.Adapt<List<Question>>();

        await Context.Questions.AddRangeAsync(newQuestions, ct);

        var existingQuestions = new List<Question>();
        if (req.ExistingQuestionIds.Length > 0)
        {
            existingQuestions = await _questionService.GetQuestionsByIdsAsync(req.ExistingQuestionIds, ct);
        }

        var quiz = new Quiz
        {
            Name = req.Name,
            Questions = newQuestions.Concat(existingQuestions).ToList()
        };

        await Context.Quizzes.AddAsync(quiz, ct);
        await Context.SaveChangesAsync(ct);

        var response = new CreateQuizResponse()
        {
            Id = quiz.Id
        };

        await SendOkAsync(response, ct);
    }
}
