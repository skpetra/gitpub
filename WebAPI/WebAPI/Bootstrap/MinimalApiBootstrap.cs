using FastEndpoints;
using FastEndpoints.Swagger;

namespace WebAPI.Bootstrap;

/// <summary>
/// Bootstrap extension methods for configuring FastEndpoints and minimal APIs.
/// </summary>
public static class MinimalApiBootstrap
{
    /// <summary>
    /// Registers FastEndpoints services and Swagger documentation with the dependency injection container.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> to configure.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance with FastEndpoints and Swagger services registered.</returns>
    public static WebApplicationBuilder AddMinimalApis(this WebApplicationBuilder builder)
    {
        builder.Services.AddFastEndpoints();
        AddSwaggerDocuments(builder.Services);

        return builder;
    }

    /// <summary>
    /// Configures the FastEndpoints middleware in the HTTP pipeline and sets a base route prefix.
    /// In development environment, also enables Swagger UI generation.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance with FastEndpoints middleware configured.</returns>
    public static WebApplication UseMinimalApis(this WebApplication app)
    {
        app.UseFastEndpoints(c =>
        {
            c.Endpoints.RoutePrefix = "api";

            c.Versioning.Prefix = "v";
            c.Versioning.PrependToRoute = true;
        });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerGen();
        }

        return app;
    }

    /// <summary>
    /// Registers Swagger document generation services for FastEndpoints with custom API documentation settings.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add Swagger services to.</param>
    private static void AddSwaggerDocuments(IServiceCollection services)
    {
        services.SwaggerDocument(options =>
        {
            options.DocumentSettings = settings =>
            {
                settings.Title = "GitPub API";
                settings.DocumentName = "Version 1";
                settings.Version = "v1";
            };
        });
    }
}
