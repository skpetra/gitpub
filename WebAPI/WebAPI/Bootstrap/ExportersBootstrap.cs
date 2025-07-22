using System.Composition.Hosting;
using System.Reflection;
using WebAPI.BL.Services.Interfaces;

namespace WebAPI.Bootstrap;

/// <summary>
/// Provides extension methods for registering quiz exporters using the Managed Extensibility Framework (MEF).
/// Supports both built-in exporters from the main assembly and external exporters loaded from configured directories,
/// enabling dynamic addition of new export formats without recompiling the main application.
/// </summary>
public static class ExportersBootstrap
{
    /// <summary>
    /// Registers all quiz exporters found in the main BL assembly where the <see cref="IQuizExporter"/> 
    /// interface is defined, as well as optional external plugin assemblies from a configured directory, using MEF composition.
    /// 
    /// All exporters must implement the <see cref="IQuizExporter"/> interface and be decorated with 
    /// <see cref="System.Composition.ExportAttribute"/> to be automatically discovered.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> used for registering dependencies.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> used to read the exporter plugin directory path.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> with exporters registered.</returns>
    /// <remarks>
    /// To enable discovery of external exporters, define a configuration section:
    /// <code>
    /// "ExporterSettings": {
    ///     "Directory": "C:\\Exporters"
    /// }
    /// </code>
    /// The specified directory and all its subdirectories are recursively scanned for .dll files.
    /// </remarks>
    public static IServiceCollection AddQuizExporters(this IServiceCollection services, IConfiguration configuration)
    {
        var containerConfig = new ContainerConfiguration()
            .WithAssembly(typeof(IQuizExporter).Assembly);

        var externalAssemblies = LoadExternalAssemblies(configuration);
        if (externalAssemblies.Any())
        {
            containerConfig = containerConfig.WithAssemblies(externalAssemblies);
        }

        using var container = containerConfig.CreateContainer();
        var exporters = container.GetExports<IQuizExporter>();

        RegisterExporters(services, exporters);

        return services;
    }

    /// <summary>
    /// Loads external exporter assemblies from the configured directory.
    /// Recursively scans the directory and all subdirectories for .dll files.
    /// </summary>
    /// <param name="configuration">The configuration instance to read the directory path from.</param>
    /// <returns>A collection of successfully loaded assemblies, or an empty collection if none are found.</returns>
    private static IEnumerable<Assembly> LoadExternalAssemblies(IConfiguration configuration)
    {
        var dir = configuration["ExporterSettings:Directory"];
        if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
        {
            return [];
        }

        return Directory
            .EnumerateFiles(dir, "*.dll", SearchOption.AllDirectories)
            .Select(Assembly.LoadFrom);
    }

    /// <summary>
    /// Registers the discovered quiz exporters as singleton services in the dependency injection container.
    /// Each exporter is registered with the <see cref="IQuizExporter"/> service type.
    /// </summary>
    /// <param name="services">Service collection to register exporters in.</param>
    /// <param name="exporters">Collection of exporter instances to register.</param>
    private static void RegisterExporters(IServiceCollection services, IEnumerable<IQuizExporter> exporters)
    {
        foreach (var exporter in exporters)
        {
            services.AddSingleton(typeof(IQuizExporter), exporter);
        }
    }
}
