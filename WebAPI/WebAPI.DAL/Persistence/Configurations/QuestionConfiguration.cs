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

        builder.HasData(
            new Question { Id = 1, Text = "Koji je kemijski simbol za srebro?", Answer = "Ag" },
            new Question { Id = 2, Text = "Koji je prvi stih poznatog romana Moby Dick?", Answer = "Nazovite me Ishmael" },
            new Question { Id = 3, Text = "Koja je najmanja ptica na svijetu?", Answer = "Pčelinji hummingbird" },
            new Question { Id = 4, Text = "Kako je Barbieino puno ime?", Answer = "Barbara Millicent Roberts" },
            new Question { Id = 5, Text = "U čemu Paul Hunn drži rekord, koji je iznosio 118.1 decibela?", Answer = "Najglasnija burka" },
            new Question { Id = 6, Text = "Koji je bio Disneyjev prvi crtić u boji?", Answer = "Cvijeće i drveće" },
            new Question { Id = 7, Text = "Koji je glavni grad Portugala?", Answer = "Lisabon" },
            new Question { Id = 8, Text = "Koliko udaha ljudsko tijelo napravi dnevno?", Answer = "20,000" },
            new Question { Id = 9, Text = "Tko je bio premijer Velike Britanije od 1841. do 1846.?", Answer = "Robert Peel" },
            new Question { Id = 10, Text = "Koje je zanimanje pisalo na Al Caponeovoj posjetnici?", Answer = "Prodavač rabljenog namještaja" },
            new Question { Id = 11, Text = "Tko je izumio limenku za konzerviranje hrane 1810. godine?", Answer = "Peter Durand" },
            new Question { Id = 12, Text = "Koja je američka pop grupa iz 1960-ih stvorila \"surfin\" zvuk'?", Answer = "Beach Boys" },
            new Question { Id = 13, Text = "U kojoj su godini Beatlesi prvi put otišli u SAD?", Answer = "1964" },
            new Question { Id = 14, Text = "Tko je bio glavni pjevač pop grupe Slade iz 1970-ih?", Answer = "Nodi Holder" },
            new Question { Id = 15, Text = "Kako se zvala Adelina prva ploča?", Answer = "Slava rodnog grada" },
            new Question { Id = 16, Text = "\"Future Nostalgia\" koji sadrži singl \"Don't Start Now\" drugi je studijski album s kojeg engleskog pjevača?", Answer = "Dua Lipa" },
            new Question { Id = 17, Text = "Kako se zove bend sa sljedećim članovima: John Deacon, Brian May, Freddie Mercury, Roger Taylor?", Answer = "Kraljica" },
            new Question { Id = 18, Text = "Koji je pjevač između ostalog bio poznat kao \"Kralj popa\" i \"The Gloved One\"?", Answer = "Michael Jackson" },
            new Question { Id = 19, Text = "Koja je američka pop zvijezda postigla uspjeh na ljestvicama 2015. sa singlovima \"Sorry\" i \"Love Yourself\"?", Answer = "Justin Bieber" },
            new Question { Id = 20, Text = "Kako se zove najnovija turneja Taylor Swift?", Answer = "Turneja Eras" },
            new Question { Id = 21, Text = "Koja pjesma ima sljedeći tekst: \"Mogu li dobiti vašu pozornost, molim/Mogu li dobiti vašu pozornost, molim?\"", Answer = "Prava vitka sjenka" }
        );
    }
}
