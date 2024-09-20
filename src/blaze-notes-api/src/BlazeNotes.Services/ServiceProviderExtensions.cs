using BlazeNotes.Data;
using BlazeNotes.Data.Interfaces;
using BlazeNotes.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlazeNotes.Services;

public static class ServiceProviderExtensions
{
    public static void AddRequiredServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IToDoListRepository, ToDoListRepository>();
        services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
        services.AddScoped<INotesRepository, NotesRepository>();
        services.AddScoped<INoteToDoTaskMappingRepository, NoteTasksMappingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IToDoService, ToDoService>();
    }
}
