using JustinaSimulator.Application.Interfaces;
using JustinaSimulator.Application.UseCases.MovePointer;
using JustinaSimulator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Domain/Application Services
builder.Services.AddScoped<MovePointerHandler>();
builder.Services.AddScoped<JustinaSimulator.Application.UseCases.Click.ClickHandler>();

// Infrastructure Services
var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JustinaSimulator.db");
builder.Services.AddDbContext<JustinaDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}",
    b => b.MigrationsAssembly("JustinaSimulator.API")));

builder.Services.AddScoped<ISimulationStateRepository, SqliteSimulationRepository>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("https://localhost:7080", "http://localhost:5242", "https://justina-blazor.azurewebsites.net")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

// Migrate DB on startup (Essential for Azure App Service)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<JustinaDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    // Standard Swagger for reliability
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
