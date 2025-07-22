using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "Text" },
                values: new object[,]
                {
                    { 1, "Ag", "Koji je kemijski simbol za srebro?" },
                    { 2, "Nazovite me Ishmael", "Koji je prvi stih poznatog romana Moby Dick?" },
                    { 3, "Pčelinji hummingbird", "Koja je najmanja ptica na svijetu?" },
                    { 4, "Barbara Millicent Roberts", "Kako je Barbieino puno ime?" },
                    { 5, "Najglasnija burka", "U čemu Paul Hunn drži rekord, koji je iznosio 118.1 decibela?" },
                    { 6, "Cvijeće i drveće", "Koji je bio Disneyjev prvi crtić u boji?" },
                    { 7, "Lisabon", "Koji je glavni grad Portugala?" },
                    { 8, "20,000", "Koliko udaha ljudsko tijelo napravi dnevno?" },
                    { 9, "Robert Peel", "Tko je bio premijer Velike Britanije od 1841. do 1846.?" },
                    { 10, "Prodavač rabljenog namještaja", "Koje je zanimanje pisalo na Al Caponeovoj posjetnici?" },
                    { 11, "Peter Durand", "Tko je izumio limenku za konzerviranje hrane 1810. godine?" },
                    { 12, "Beach Boys", "Koja je američka pop grupa iz 1960-ih stvorila \"surfin\" zvuk'?" },
                    { 13, "1964", "U kojoj su godini Beatlesi prvi put otišli u SAD?" },
                    { 14, "Nodi Holder", "Tko je bio glavni pjevač pop grupe Slade iz 1970-ih?" },
                    { 15, "Slava rodnog grada", "Kako se zvala Adelina prva ploča?" },
                    { 16, "Dua Lipa", "\"Future Nostalgia\" koji sadrži singl \"Don't Start Now\" drugi je studijski album s kojeg engleskog pjevača?" },
                    { 17, "Kraljica", "Kako se zove bend sa sljedećim članovima: John Deacon, Brian May, Freddie Mercury, Roger Taylor?" },
                    { 18, "Michael Jackson", "Koji je pjevač između ostalog bio poznat kao \"Kralj popa\" i \"The Gloved One\"?" },
                    { 19, "Justin Bieber", "Koja je američka pop zvijezda postigla uspjeh na ljestvicama 2015. sa singlovima \"Sorry\" i \"Love Yourself\"?" },
                    { 20, "Turneja Eras", "Kako se zove najnovija turneja Taylor Swift?" },
                    { 21, "Prava vitka sjenka", "Koja pjesma ima sljedeći tekst: \"Mogu li dobiti vašu pozornost, molim/Mogu li dobiti vašu pozornost, molim?\"" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kviz opće kulture" },
                    { 2, "Mali glazbeni kviz" }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "QuestionsId", "QuizzesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 12, 2 },
                    { 13, 1 },
                    { 13, 2 },
                    { 14, 1 },
                    { 14, 2 },
                    { 15, 1 },
                    { 15, 2 },
                    { 16, 1 },
                    { 16, 2 },
                    { 17, 1 },
                    { 17, 2 },
                    { 18, 1 },
                    { 18, 2 },
                    { 19, 1 },
                    { 19, 2 },
                    { 20, 1 },
                    { 20, 2 },
                    { 21, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionsId", "QuizzesId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
