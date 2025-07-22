namespace WebAPI.BL.Models.Quiz;

using WebAPI.DAL.Models;

public record QuizDto : BaseDto<QuizDto, Quiz>
{
    public required string Name { get; set; }
}
