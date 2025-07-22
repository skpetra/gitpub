using Serilog;

namespace WebAPI.Bootstrap;

public static class LoggingBootstrap
{
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) =>
            config.ReadFrom.Configuration(context.Configuration)
        );
    }
}
