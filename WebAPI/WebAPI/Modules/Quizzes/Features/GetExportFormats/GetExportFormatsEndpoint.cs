using FastEndpoints;
using WebAPI.BL.Services.Interfaces;
using WebAPI.Core;

namespace WebAPI.Modules.Quizzes.Features.GetExportFormats;

public class GetExportFormatsEndpoint : ApiEndpoint<EmptyRequest, GetExportFormatsResponse>
{
    private readonly IExportService _exportService;

    public GetExportFormatsEndpoint(IExportService exportService)
    {
        _exportService = exportService;
    }

    public override void Configure()
    {
        Get("quizzes/export-formats");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Retrieves supported export formats for quizzes.";
            s.Description = "Returns a list of supported formats that can be used to export quizzes.";
        });
    }

    public override Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var supportedFormats = _exportService.GetSupportedFormats().ToList();

        var response = new GetExportFormatsResponse
        {
            SupportedFormats = supportedFormats
        };

        return SendOkAsync(response, ct);
    }
}
