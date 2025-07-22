namespace WebAPI.Modules.Quizzes.Features.GetExportFormats;

public record GetExportFormatsResponse
{
    public List<string> SupportedFormats { get; set; } = new List<string>();
}
