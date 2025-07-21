using WebAPI.DAL.Models;

namespace WebAPI.BL.Models.Questions;

public record QuestionAddDto : BaseDto<QuestionAddDto, Question>
{
    public string Text { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}
