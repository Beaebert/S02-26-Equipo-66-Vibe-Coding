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
builder.Services.AddDbContext<JustinaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=JustinaSimulator.db",
    b => b.MigrationsAssembly("JustinaSimulator.API")));

builder.Services.AddScoped<ISimulationStateRepository, SqliteSimulationRepository>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    // Standard Swagger for reliability
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
