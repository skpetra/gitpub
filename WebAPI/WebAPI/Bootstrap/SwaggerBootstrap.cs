using Microsoft.OpenApi.Models;

namespace WebAPI.Bootstrap;

/// <summary>
/// Provides extension methods for configuring and enabling Swagger using Swashbuckle.
/// </summary>
public static class SwaggerBootstrap
{
    /// <summary>
    /// Registers Swagger generator services in the dependency injection container.
    /// Adds a Swagger document with the specified title and version.
    /// </summary>
    /// <param name="services">The IServiceCollection to add Swagger services to.</param>
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "GitPub API", Version = "v1" });
        });
    }

    /// <summary>
    /// Enables the Swagger middleware in the application's HTTP request pipeline.
    /// This exposes the Swagger JSON and UI endpoints.
    /// </summary>
    /// <param name="app">The IApplicationBuilder to configure.</param>
    public static void EnableSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
