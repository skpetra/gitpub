using FluentValidation;
using WebAPI.BL.Models.Questions;
using WebAPI.Core.Validation;

namespace WebAPI.Modules.Quizzes.Features.UpdateQuiz;

public class UpdateQuizValidator(IValidator<QuestionAddDto> questionValidator) : BaseQuizValidator<UpdateQuizRequest>(questionValidator);
