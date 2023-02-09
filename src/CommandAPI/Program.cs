using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
