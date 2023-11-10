global using Microsoft.EntityFrameworkCore;
global using ToDoList.Data;
using ToDoList.Services.ToDoService;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("CORS", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IToDoService, ToDoService>();

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

app.UseCors("CORS");

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
