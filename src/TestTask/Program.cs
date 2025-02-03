using Microsoft.EntityFrameworkCore;
using TestTask.DAL;
using TestTask.DAL.Abstractions;
using TestTask.DAL.Repositories;
using TestTask.Services;
using TestTask.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("Data Source=Server;" +
  "Initial Catalog=DataBase;" +
  "User id=User;" +
  "Password=12345"));

builder.Services.AddScoped<IMouseTrackingRepository, MouseTrackingRepository>();
builder.Services.AddScoped<IMouseTrackingService, MouseTrackingService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NoCors",
        builder => builder.AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("NoCors");

app.MapControllers();

app.Run();