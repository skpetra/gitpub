using Serilog;
using WebAPI.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();
builder.AddDatabaseContext();

builder.AddMinimalApis();

builder.Services.AddMapster();
builder.Services.AddBusinessLogic();
builder.Services.AddQuizExporters(builder.Configuration);

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseMinimalApis();

app.UseHttpsRedirection();

await app.RunAsync();