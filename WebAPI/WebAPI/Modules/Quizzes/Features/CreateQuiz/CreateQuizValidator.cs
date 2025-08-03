using FluentValidation;
using WebAPI.BL.Models.Questions;
using WebAPI.Core.Models;
using WebAPI.Core.Validation;

namespace WebAPI.Modules.Quizzes.Features.CreateQuiz;

public class CreateQuizValidator(IValidator<QuestionAddDto> questionValidator) : BaseQuizValidator<BaseQuizRequest>(questionValidator);