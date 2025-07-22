using WebAPI.DAL.Models;

namespace WebAPI.BL.Models.Questions;

public record QuestionAddDto : BaseDto<QuestionAddDto, Question>
{
    public required string Text { get; set; }
    public required string Answer { get; set; }
}
