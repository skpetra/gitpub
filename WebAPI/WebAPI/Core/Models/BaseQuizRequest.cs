using WebAPI.BL.Models.Questions;

namespace WebAPI.Core.Models;

public record BaseQuizRequest
{
    public required string Name { get; set; }
    public List<QuestionAddDto> NewQuestions { get; set; } = [];
    public int[] ExistingQuestionIds { get; set; } = [];
}
