using Api.App.Interfaces;
using Api.Infrastructure.Data;
using Api.Infrastructure.Repositories;
using Api.Middleware;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Api.App.Services;

// Логгер т.к. есть обработчик исключений
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Error()
	.WriteTo.File(
		path: "Logs/errors-.log",
		rollingInterval: RollingInterval.Day
	)
	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddScoped<ITaskQueryService, TaskQueryService>();
builder.Services.AddScoped<ITaskService, TaskCommandService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskEventRepository, TaskEventRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Обработчик исключений
app.UseMiddleware<ExceptionHandlingMiddleware>();

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
