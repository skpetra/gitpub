using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Persistence;

namespace WebAPI.Bootstrap;

/// <summary>
/// Provides extension methods for configuring the application's database context.
/// </summary>
public static class DatabaseBootstrap
{
    /// <summary>
    /// Registers the <see cref="AppDbContext"/> with the dependency injection container
    /// using the SQL Server provider and the connection string named "AppDB".
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> to configure.</param>
    public static void AddDatabaseContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("AppDB");

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);
    }

    /// <summary>
    /// Applies any pending database migrations when the application starts.
    /// Ensures that the database schema matches the current data model.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
