using BlazeNotes.Domain;

namespace BlazeNotes.Services.Interfaces;

public interface IToDoService
{
    Task<List<ToDoList>> GetAllToDoList();

    Task<ToDoList> GetToDoListByGuid(Guid guid);

    Task AddToDoList(ToDoList toDoList);

    Task<ToDoList> AddToDoTasksToList(Guid guid, List<ToDoTask> toDoTasks);

    Task DeleteToDoList(Guid guid);

    Task<List<ToDoTask>> GetSampleToDoList();
}
