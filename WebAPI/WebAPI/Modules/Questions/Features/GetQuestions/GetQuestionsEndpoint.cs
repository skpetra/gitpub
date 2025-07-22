using Microsoft.EntityFrameworkCore;
using WebAPI.BL.Models.Questions;
using WebAPI.Core;

namespace WebAPI.Modules.Questions.Features.GetQuestions;

public class GetQuestionsEndpoint : ApiEndpoint<GetQuestionsRequest, GetQuestionsResponse>
{
    public override void Configure()
    {
        Get("questions");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Fetches existing questions with optional text search and pagination.";
            s.Description = "Returns a paginated list of existing questions that can be filtered by a search term." +
                " Use page number and page size parameters to control the output.";
        });
    }

    public override async Task HandleAsync(GetQuestionsRequest req, CancellationToken ct)
    {
        var query = Context.Questions.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(req.SearchTerm))
        {
            query = query.Where(q => q.Text != null && q.Text.Contains(req.SearchTerm));
        }

        var totalCount = await query.CountAsync(ct);

        var questions = await query
            .Skip(req.PageNumber * req.PageSize)
            .Take(req.PageSize)
            .Select(q => QuestionDto.FromEntity(q))
            .ToListAsync(ct);

        await SendOkAsync(new GetQuestionsResponse(totalCount, questions), ct);
    }
}
