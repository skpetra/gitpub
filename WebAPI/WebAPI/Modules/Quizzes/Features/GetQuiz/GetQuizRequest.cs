using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Modules.Quizzes.Features.GetQuiz;

public record GetQuizRequest([FromRoute] int QuizId);