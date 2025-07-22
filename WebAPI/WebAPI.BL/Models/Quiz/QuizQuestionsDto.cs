namespace WebAPI.BL.Models.Quiz;

using WebAPI.BL.Models.Questions;
using WebAPI.DAL.Models;

public record QuizQuestionsDto : BaseDto<QuizQuestionsDto, Quiz>
{
    public required string Name { get; set; }
    public List<QuestionDto> Questions { get; set; } = [];
}
