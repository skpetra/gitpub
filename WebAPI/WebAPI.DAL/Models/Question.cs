using WebAPI.DAL.Models.Common;

namespace WebAPI.DAL.Models;

public class Question : Entity
{
    public required string Text { get; set; }
    public required string Answer { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; } = [];
}
