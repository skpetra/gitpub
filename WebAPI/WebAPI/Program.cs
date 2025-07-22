using WebAPI.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.AddMinimalApis();

builder.Services.AddMapster();
builder.Services.AddBusinessLogic();
builder.Services.AddQuizExporters(builder.Configuration);

var app = builder.Build();

app.UseMinimalApis();

app.UseHttpsRedirection();

await app.RunAsync();