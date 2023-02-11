using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

var b = new NpgsqlConnectionStringBuilder();
b.ConnectionString = configuration.GetConnectionString("PostgreSqlConnection");
b.Username = configuration["UserID"];
b.Password = configuration["Password"];

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(b.ConnectionString));

builder.Services.AddControllers();

//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
