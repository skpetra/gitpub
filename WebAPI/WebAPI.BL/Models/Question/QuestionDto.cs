using WebAPI.DAL.Models;

namespace WebAPI.BL.Models.Questions;

public record QuestionDto : BaseDto<QuestionDto, Question>
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}
