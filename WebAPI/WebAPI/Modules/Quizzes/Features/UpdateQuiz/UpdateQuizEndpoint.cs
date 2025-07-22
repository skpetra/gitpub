using FastEndpoints;
using Mapster;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core;
using WebAPI.DAL.Models;

namespace WebAPI.Modules.Quizzes.Features.UpdateQuiz;

public class UpdateQuizEndpoint : ApiEndpoint<UpdateQuizRequest, EmptyResponse>
{
    public override void Configure()
    {
        Put("quizzes/{quizId}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Updates an existing quiz.";
            s.Description = "Updates an existing quiz's name and its list of questions. " +
                "You can add newly created questions as well as reference existing questions by their IDs. " +
                "The updated quiz will include both new and previously existing questions.";
        });
    }

    public override async Task HandleAsync(UpdateQuizRequest req, CancellationToken ct)
    {
        var quiz = await Context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(q => q.Id == req.QuizId, ct);

        if (quiz is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        quiz.Name = req.Name;

        var newQuestions = req.NewQuestions.Adapt<List<Question>>();

        var questionsToRemove = quiz.Questions.Where(q => !req.ExistingQuestionIds.Contains(q.Id)).ToList();
        var questionsIdsToAdd = req.ExistingQuestionIds.Except(quiz.Questions.Select(q => q.Id)).ToList();

        foreach (var question in questionsToRemove)
        {
            quiz.Questions.Remove(question);
        }

        var existingQuestionsToAdd = await Context.Questions
            .Where(q => questionsIdsToAdd.Contains(q.Id))
            .ToListAsync(ct);

        foreach (var question in existingQuestionsToAdd.Concat(newQuestions))
        {
            quiz.Questions.Add(question);
        }

        Context.Update(quiz);
        await Context.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}
