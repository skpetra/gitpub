using WebAPI.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.AddMinimalApis();

builder.Services.AddMapster();
builder.Services.AddBusinessLogic();

var app = builder.Build();

app.UseMinimalApis();

app.UseHttpsRedirection();

await app.RunAsync();