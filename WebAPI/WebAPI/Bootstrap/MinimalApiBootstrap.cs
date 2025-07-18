using FastEndpoints;

namespace WebAPI.Bootstrap;

/// <summary>
/// Bootstrap extension methods for configuring FastEndpoints and minimal APIs.
/// </summary>
public static class MinimalApiBootstrap
{
    /// <summary>
    /// Registers FastEndpoints services in the dependency injection container.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder instance.</param>
    /// <returns>The WebApplicationBuilder instance with FastEndpoints services registered.</returns>
    public static WebApplicationBuilder AddMinimalApis(this WebApplicationBuilder builder)
    {
        builder.Services.AddFastEndpoints();

        return builder;
    }

    /// <summary>
    /// Configures the FastEndpoints middleware in the HTTP pipeline and sets a base route prefix.
    /// </summary>
    /// <param name="app">The WebApplication instance.</param>
    /// <returns>The WebApplication instance with FastEndpoints middleware configured.</returns>
    public static WebApplication UseMinimalApis(this WebApplication app)
    {
        app.UseFastEndpoints(c =>
        {
            c.Endpoints.RoutePrefix = "api";
        });

        return app;
    }
}
