using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

builder.Services.AddControllers();

//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
