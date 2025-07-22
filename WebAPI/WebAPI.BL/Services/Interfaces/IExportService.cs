namespace WebAPI.BL.Services.Interfaces;

public interface IExportService
{
    bool IsFormatSupported(string format);
    IEnumerable<string> GetSupportedFormats();
}
