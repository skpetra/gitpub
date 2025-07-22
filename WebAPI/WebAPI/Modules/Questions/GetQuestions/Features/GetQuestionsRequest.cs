using WebAPI.Core.Models;

namespace WebAPI.Modules.Questions.GetQuestions.Features;

public record GetQuestionsRequest : BasePaginatedRequest
{
    public string? SearchTerm { get; set; }
}
