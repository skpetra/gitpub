using FastEndpoints;
using FluentValidation;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Constants;
using WebAPI.Core.Models;
using WebAPI.DAL.Models.Common;

namespace WebAPI.Core.Validation;

public abstract class BaseQuizValidator<T> : Validator<T>
    where T : BaseQuizRequest
{
    protected BaseQuizValidator()
    {
        RuleFor(x => x.Name)
            .MustAsync(NameDoesNotExist)
                .WithMessage(ErrorConstants.Quiz.NameAlreadyExists)
            .MaximumLength(LengthConstants.NameLength)
                .WithMessage(x => ValidationMessages.MaxLength(nameof(x.Name), LengthConstants.NameLength));

        RuleFor(x => x.ExistingQuestionIds)
            .MustAsync(AllQuestionIdsExist)
                .WithMessage(ErrorConstants.Quiz.SelectedQuestionsDoNotExist)
            .When(x => x.ExistingQuestionIds.Length > 0);
    }

    private async Task<bool> NameDoesNotExist(string name, CancellationToken ct)
    {
        var quizService = Resolve<IQuizService>();

        return !await quizService.DoesNameExistAsync(name, ct);
    }

    private async Task<bool> AllQuestionIdsExist(int[] questionIds, CancellationToken ct)
    {
        var questionService = Resolve<IQuestionService>();

        return await questionService.DoAllQuestionsExistAsync(questionIds, ct);
    }
}
