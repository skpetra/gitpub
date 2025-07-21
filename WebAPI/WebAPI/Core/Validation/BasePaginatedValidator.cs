using FastEndpoints;
using FluentValidation;
using WebAPI.Constants;
using WebAPI.Core.Models;

namespace WebAPI.Core.Validation;

public class BasePaginatedValidator : Validator<BasePaginatedRequest>
{
    public BasePaginatedValidator()
    {
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(FilteringConstants.MinimumPageSize)
            .LessThanOrEqualTo(FilteringConstants.MaximumPageSize);

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(FilteringConstants.MinimumPageNumber);
    }
}