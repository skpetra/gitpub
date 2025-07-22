using WebAPI.Core.Models;

namespace WebAPI.Modules.Questions.Features.GetQuestions;

public record GetQuestionsRequest : BasePaginatedRequest
{
    public string? SearchTerm { get; set; }
}
