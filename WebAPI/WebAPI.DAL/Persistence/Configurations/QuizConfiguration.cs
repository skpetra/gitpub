using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.DAL.Models;
using WebAPI.DAL.Models.Common;

namespace WebAPI.DAL.Persistence.Configurations;

internal class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.SetupEntity();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(LengthConstants.NameLength);

        builder.HasIndex(x => x.Name);

        builder.HasData(
            new Quiz { Id = 1, Name = "Kviz opće kulture" },
            new Quiz { Id = 2, Name = "Mali glazbeni kviz" }
        );
    }
}
