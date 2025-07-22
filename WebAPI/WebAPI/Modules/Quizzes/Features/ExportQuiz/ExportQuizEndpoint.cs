using FastEndpoints;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Core;

namespace WebAPI.Modules.Quizzes.Features.ExportQuiz;

public class ExportQuizEndpoint : ApiEndpoint<ExportQuizRequest, EmptyResponse>
{
    private readonly IQuizService _quizService;
    private readonly IExportService _exportService;
    private readonly IEnumerable<IQuizExporter> _exporters;
    private readonly ILogger<ExportQuizEndpoint> _logger;

    public ExportQuizEndpoint(IQuizService quizService, IExportService exportService, IEnumerable<IQuizExporter> exporters, ILogger<ExportQuizEndpoint> logger)
    {
        _quizService = quizService;
        _exportService = exportService;
        _exporters = exporters;
        _logger = logger;
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
            _logger.LogWarning("Quiz with id '{QuizId}' not found.", req.QuizId);
            await SendNotFoundAsync(ct);
            return;
        }

        var exporter = _exporters.FirstOrDefault(e => e.Format.Equals(req.Format, StringComparison.InvariantCultureIgnoreCase));
        if (exporter is null)
        {
            _logger.LogWarning("Export format '{Format}' is not supported.", req.Format);
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var fileBytes = await exporter.ExportAsync(quiz, ct);
        await SendBytesAsync(fileBytes, $"{quiz.Name}.{exporter.Format}", exporter.ContentType, cancellation: ct);
    }
}
