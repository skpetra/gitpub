using WebAPI.DAL.Models.Common;

namespace WebAPI.DAL.Models;

public class Quiz : Entity
{
    public required string Name { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = [];
}