using FastEndpoints;
using FluentValidation;
using WebAPI.Constants;

namespace WebAPI.Modules.Questions.Features.GetQuestions;

public class GetQuestionsValidator : Validator<GetQuestionsRequest>
{
    public GetQuestionsValidator()
    {
        When(x => x.SearchTerm is not null, () =>
        {
            RuleFor(x => x.SearchTerm)
                .MaximumLength(FilteringConstants.SearchCharacterLimit);
        });
    }
}
