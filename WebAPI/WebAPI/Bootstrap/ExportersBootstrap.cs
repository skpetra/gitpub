using System.Composition.Hosting;
using WebAPI.BL.Services.Interfaces;

namespace WebAPI.Bootstrap;

/// <summary>
/// Provides extension methods for registering quiz exporters using Managed Extensibility Framework (MEF).
/// Automatically discovers and registers all classes that implement <see cref="IQuizExporter"/> interface
/// and are decorated with MEF export attributes.
/// </summary>
public static class ExportersBootstrap
{
    /// <summary>
    /// Registers all quiz exporters found in the BL assembly where the <see cref="IQuizExporter"/> 
    /// interface is defined, using MEF composition.
    /// Exporters must implement <see cref="IQuizExporter"/> interface and be decorated with 
    /// <see cref="System.Composition.ExportAttribute"/> to be automatically discovered.
    /// All exporters are registered as singleton services since they are stateless utility classes.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add exporter services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance with quiz exporters registered.</returns>
    public static IServiceCollection AddQuizExporters(this IServiceCollection services)
    {
        var configuration = new ContainerConfiguration()
            .WithAssembly(typeof(IQuizExporter).Assembly);

        using var container = configuration.CreateContainer();
        var exporters = container.GetExports<IQuizExporter>();

        foreach (var exporter in exporters)
        {
            services.AddSingleton(typeof(IQuizExporter), exporter);
        }

        return services;
    }
}
