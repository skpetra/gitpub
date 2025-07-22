using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebAPI.Bootstrap
{
    /// <summary>
    /// Provides extension methods for configuring Mapster object-to-object mapping.
    /// </summary>
    public static class MapsterConfiguration
    {
        /// <summary>
        /// Configures Mapster global settings by scanning the executing assembly for mapping configurations.
        /// This method discovers and registers all classes that implement <see cref="IRegister"/> interface,
        /// such as DTOs that inherit from <see cref="BaseDto{TDto, TEntity}"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
