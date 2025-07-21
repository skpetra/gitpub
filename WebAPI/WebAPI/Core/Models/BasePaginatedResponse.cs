namespace WebAPI.Core.Models;

public record BasePaginatedResponse<T>(int TotalCount, IReadOnlyList<T> Data)
    where T : class;
