using BlazeNotes.API;
using BlazeNotes.Domain;
using BlazeNotes.Services;
using BlazeNotes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlazeAppContext>(options =>
    options.UseSqlite("data source=blaze.db")
);

builder.Services.AddRequiredServices();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.RouteTemplate = "openapi/{documentName}.json");
    app.MapScalarApiReference(options =>
        {
            options.Title = "Blaze Notes API";
            options.Theme = ScalarTheme.Mars;
            options.Authentication = new ScalarAuthenticationOptions
            {
                PreferredSecurityScheme = "ApiKey",
                ApiKey = new ApiKeyOptions { Token = "api-key" }
            };
        })
        .WithDisplayName("Blaze Notes API")
        .WithDescription("APIs for notes and to-do list");
}

app.UseCors(options =>
{
    options.AllowAnyMethod().AllowAnyHeader();
    options.WithOrigins("http://localhost:4200");
});

app.UseMiddleware<ApiKeyMiddleWare>();

app.UseHttpsRedirection();

app.MapGet(
    "/todos/sample",
    async (IToDoService toDoService) => Results.Ok(await toDoService.GetSampleToDoList())
);

app.MapGet(
    "/todos/get/all",
    async (IToDoService toDoService) => Results.Ok(await toDoService.GetAllToDoList())
);

app.MapGet(
    "todos/get/{guid}",
    async (IToDoService toDoService, Guid guid) =>
        Results.Ok(await toDoService.GetToDoListByGuid(guid))
);

app.MapPost(
    "/todos",
    async (IToDoService toDoService, [FromBody] List<ToDoTask> tasks) =>
    {
        var toDoList = new ToDoList { ToDoTasks = tasks };
        await toDoService.AddToDoList(toDoList);
        var item = await toDoService.GetToDoListByGuid(toDoList.ListGuid);

        return Results.Ok(item);
    }
);

app.MapPut(
    "/todos/{guid}",
    async (IToDoService toDoService, Guid guid, [FromBody] List<ToDoTask> tasks) =>
    {
        var item = await toDoService.AddToDoTasksToList(guid, tasks);
        return Results.Ok(item);
    }
);

app.Run();
