namespace WebAPI.Core.Models;

public record BasePaginatedRequest
{
    public int PageSize { get; init; } = 10;
    public int PageNumber { get; init; } = 0;
}
