using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Models;

namespace WebAPI.Modules.Quizzes.Features.UpdateQuiz;

public record UpdateQuizRequest([FromRoute] int QuizId) : BaseQuizRequest;