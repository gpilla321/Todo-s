using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using TodoListAPI.Repository;
using TodoListAPI.Repository.Interface;
using TodoListAPI.Service;
using TodoListAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var exception = context.Features.Get<IExceptionHandlerPathFeature>();

        return context.Response.WriteAsJsonAsync(exception?.Error.Message);
    });
});

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
