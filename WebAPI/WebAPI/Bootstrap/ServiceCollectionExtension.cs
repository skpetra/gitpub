using WebAPI.BL.Services;
using WebAPI.BL.Services.Interfaces;

namespace WebAPI.Bootstrap;

/// <summary>
/// Provides extension methods for registering business logic services with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Registers all business logic services with their corresponding interfaces in the dependency injection container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance with business logic services registered.</returns>
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IQuestionService, QuestionService>();

        services.AddSingleton<IExportService, ExportService>();

        return services;
    }
}
