using FastEndpoints;
using FluentValidation;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Constants;

namespace WebAPI.Modules.Quizzes.Features.ExportQuiz;

public class ExportQuizValidator : Validator<ExportQuizRequest>
{
    public ExportQuizValidator()
    {
        RuleFor(x => x.Format)
            .NotEmpty()
                .WithMessage(ErrorConstants.Export.ExportFormatRequired)
            .Must(BeValidFormat)
                .WithMessage(ErrorConstants.Export.UnsupportedExportFormat);
    }

    private bool BeValidFormat(string format)
    {
        var exportService = Resolve<IExportService>();

        return exportService.IsFormatSupported(format);
    }
}
