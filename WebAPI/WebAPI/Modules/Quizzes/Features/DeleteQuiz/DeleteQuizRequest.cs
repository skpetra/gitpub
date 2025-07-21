using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Modules.Quizzes.Features.DeleteQuiz;

public record DeleteQuizRequest([FromRoute] int QuizId);