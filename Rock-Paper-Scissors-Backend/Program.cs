using Microsoft.EntityFrameworkCore;
using Rock_Paper_Scissors_Backend.Data;
using Rock_Paper_Scissors_Backend.Data.Repositories;
using Rock_Paper_Scissors_Backend.Interfaces.IRepositories;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;
using Rock_Paper_Scissors_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllHeadersAndMethods",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
        });
    });

builder.Services.AddScoped<IRoundRepository, RoundRepository>();
builder.Services.AddScoped<IRoundService, RoundService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAllHeadersAndMethods");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
