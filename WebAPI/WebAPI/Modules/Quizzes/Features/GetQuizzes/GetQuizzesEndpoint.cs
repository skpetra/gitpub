using Microsoft.EntityFrameworkCore;
using WebAPI.BL.Models.Quiz;
using WebAPI.Core;
using WebAPI.Core.Models;

namespace WebAPI.Modules.Quizzes.Features.GetQuizzes;

public class GetQuizzesEndpoint : ApiEndpoint<BasePaginatedRequest, GetQuizzesResponse>
{
    public override void Configure()
    {
        Get("quizzes");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Fetches all quizzes";
            s.Description = "Returns a paginated list of all quizzes stored in the database.";
        });
    }

    public override async Task HandleAsync(BasePaginatedRequest req, CancellationToken ct)
    {
        var query = Context.Quizzes.AsNoTracking();

        var totalCount = await query.CountAsync(ct);

        var quizzes = await query
            .Skip(req.PageNumber * req.PageSize)
            .Take(req.PageSize)
            .Select(q => QuizDto.FromEntity(q))
            .ToListAsync(ct);

        await SendOkAsync(new GetQuizzesResponse(totalCount, quizzes), ct);
    }
}
