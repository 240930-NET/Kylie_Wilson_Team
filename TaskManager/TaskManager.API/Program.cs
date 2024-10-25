using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManager.API.Service;
using TaskManager.Data;
using TaskManager.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string ConnectionString = builder.Configuration.GetConnectionString("TaskManager");
builder.Services.AddDbContext<TasksContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddScoped<ITasksRepo, TasksRepo>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API V1");
        c.RoutePrefix = string.Empty; // This makes Swagger UI the root page
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();