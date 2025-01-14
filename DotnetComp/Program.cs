using Asp.Versioning;
using DotnetComp.Clients;
using DotnetComp.Data;
using DotnetComp.Repositories;
using DotnetComp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Api versioning
builder
    .Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("X-Api-Version")
        );
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHttpClient(
    "RunescapeClient",
    client => client.BaseAddress = new Uri("https://secure.runescape.com/")
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetComp - V1", Version = "v1.0" });
});

// DI
builder.Services.AddScoped<IHiscoreService, HiscoreService>();
builder.Services.AddScoped<IRunescapeClient, RunescapeClient>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// Setup database
var connectionString =
    builder.Configuration.GetConnectionString("sqlite")
    ?? throw new InvalidOperationException("Connection string for database not found.");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
