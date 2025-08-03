using FastEndpoints;
using FluentValidation;
using WebAPI.BL.Models.Questions;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Constants;
using WebAPI.Core.Models;
using WebAPI.DAL.Models.Common;

namespace WebAPI.Core.Validation;

public abstract class BaseQuizValidator<T> : Validator<T>
    where T : BaseQuizRequest
{
    protected BaseQuizValidator(IValidator<QuestionAddDto> questionValidator)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MustAsync(NameDoesNotExist)
                .WithMessage(ErrorConstants.Quiz.NameAlreadyExists)
            .MaximumLength(LengthConstants.NameLength)
                .WithMessage(x => ValidationMessages.MaxLength(nameof(x.Name), LengthConstants.NameLength));

        RuleForEach(x => x.NewQuestions)
            .SetValidator(questionValidator);

        RuleForEach(x => x.ExistingQuestionIds)
            .MustAsync(QuestionDoesNotExist)
                .WithMessage(ErrorConstants.Question.QuestionDoesNotExist);

        RuleFor(x => x)
            .Must(x => (x.NewQuestions?.Count > 0) || (x.ExistingQuestionIds?.Length > 0))
                .WithMessage(ErrorConstants.Quiz.AtLeastOneQuestionRequired);
    }

    private async Task<bool> NameDoesNotExist(string name, CancellationToken ct)
    {
        var quizService = Resolve<IQuizService>();

        return !await quizService.DoesNameExistAsync(name, ct);
    }

    private async Task<bool> QuestionDoesNotExist(int id, CancellationToken ct)
    {
        var questionService = Resolve<IQuestionService>();

        return await questionService.DoesQuestionExistByIdAsync(id, ct);
    }
}
