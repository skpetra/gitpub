using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.DAL.Models.Common;

namespace WebAPI.DAL.Persistence.Configurations;

public static class ConfigurationBuilderExtensions
{
    public static void SetupEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}