using WebAPI.DAL.Models;

namespace WebAPI.BL.Models.Questions;

public record QuestionDto : BaseDto<QuestionDto, Question>
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required string Answer { get; set; }
}
