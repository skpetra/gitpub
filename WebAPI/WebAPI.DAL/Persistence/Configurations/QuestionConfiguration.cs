using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.DAL.Models;

namespace WebAPI.DAL.Persistence.Configurations;

internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.SetupEntity();

        builder.Property(x => x.Text)
            .IsRequired();

        builder.Property(x => x.Answer)
            .IsRequired();
    }
}
