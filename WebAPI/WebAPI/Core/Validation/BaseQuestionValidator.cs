using FastEndpoints;
using FluentValidation;
using WebAPI.BL.Models.Questions;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Constants;

namespace WebAPI.Core.Validation;

public class BaseQuestionValidator : Validator<QuestionAddDto>
{
    public BaseQuestionValidator()
    {
        RuleFor(q => q.Text)
            .NotEmpty()
            .MustAsync(QuestionDoesNotExist)
                .WithMessage(ErrorConstants.Question.QuestionAlreadyExists);

        RuleFor(q => q.Answer)
            .NotEmpty();
    }

    private async Task<bool> QuestionDoesNotExist(string text, CancellationToken ct)
    {
        var questionService = Resolve<IQuestionService>();

        return !await questionService.DoesQuestionExistByTextAsync(text, ct);
    }
}