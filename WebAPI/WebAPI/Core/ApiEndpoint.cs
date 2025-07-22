using FastEndpoints;
using WebAPI.DAL.Persistence;

namespace WebAPI.Core;

public abstract class ApiEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
    where TRequest : notnull
{
    private AppDbContext? _context;
    public AppDbContext Context
    {
        get
        {
            _context ??= HttpContext!.RequestServices.GetRequiredService<AppDbContext>();
            return _context;
        }
    }
}
