using Microsoft.EntityFrameworkCore;
using WebAPI.BL.Services.Interfaces;

namespace WebAPI.BL.Services;

public class ExportService : IExportService
{
    private readonly IEnumerable<IQuizExporter> _exporters;

    public ExportService(IEnumerable<IQuizExporter> exporters)
    {
        _exporters = exporters;
    }

    public bool IsFormatSupported(string format)
    {
        var availableFormats = GetSupportedFormats();
        return availableFormats.Contains(format, StringComparer.OrdinalIgnoreCase);
    }

    public IEnumerable<string> GetSupportedFormats()
    {
        return _exporters.Select(e => e.Format);
    }
}
