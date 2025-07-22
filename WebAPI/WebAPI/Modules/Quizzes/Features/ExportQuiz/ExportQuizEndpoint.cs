using FastEndpoints;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Constants;
using WebAPI.Core;

namespace WebAPI.Modules.Quizzes.Features.ExportQuiz;

public class ExportQuizEndpoint : ApiEndpoint<ExportQuizRequest, EmptyResponse>
{
    private readonly IQuizService _quizService;
    private readonly IExportService _exportService;
    private readonly IEnumerable<IQuizExporter> _exporters;

    public ExportQuizEndpoint(IQuizService quizService, IExportService exportService, IEnumerable<IQuizExporter> exporters)
    {
        _quizService = quizService;
        _exportService = exportService;
        _exporters = exporters;
    }

    public override void Configure()
    {
        Get("quizzes/{quizId}/export");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Exports quiz in specified format.";
            s.Description = "Exports a quiz to one of the supported formats as specified by the client in the request. " +
                $"Supported formats are: {string.Join(", ", _exportService.GetSupportedFormats())}.";
        });
    }

    public override async Task HandleAsync(ExportQuizRequest req, CancellationToken ct)
    {
        var quiz = await _quizService.GetQuizAsync(req.QuizId, ct);

        if (quiz is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var exporter = _exporters.FirstOrDefault(e => e.Format.Equals(req.Format, StringComparison.InvariantCultureIgnoreCase));
        if (exporter is null)
        {
            AddError(ErrorConstants.Export.UnsupportedExportFormat);
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var fileBytes = await exporter.ExportAsync(quiz, ct);
        await SendBytesAsync(fileBytes, $"{quiz.Name}.{exporter.Format}", exporter.ContentType, cancellation: ct);
    }
}
