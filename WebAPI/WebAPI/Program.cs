using WebAPI.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.AddMinimalApis();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.EnableSwagger();
}

app.UseMinimalApis();

app.UseHttpsRedirection();

await app.RunAsync();