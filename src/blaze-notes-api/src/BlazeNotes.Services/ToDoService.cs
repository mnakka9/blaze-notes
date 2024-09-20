using System.Linq.Expressions;
using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;
using BlazeNotes.Services.Interfaces;

namespace BlazeNotes.Services;

public class ToDoService(IUnitOfWork unitOfWork) : IToDoService
{
    public Task AddToDoList(ToDoList toDoList)
    {
        ArgumentNullException.ThrowIfNull(toDoList);

        if (toDoList.ToDoTasks is null or { Count: 0 })
        {
            throw new ArgumentException("No tasks are present in list", nameof(toDoList));
        }

        if (toDoList.ToDoTasks.Any(x => string.IsNullOrEmpty(x.Title)))
        {
            throw new Exception("Invalid tasks, no title present in one of the tasks");
        }

        unitOfWork.ToDoListRepository.Add(toDoList);
        unitOfWork.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task<ToDoList> AddToDoTasksToList(Guid guid, List<ToDoTask> toDoTasks)
    {
        var listItem = await GetToDoListByGuid(guid);

        listItem ??= new();

        foreach (var task in toDoTasks)
        {
            task.Id = 0;
        }

        listItem.ToDoTasks = toDoTasks;

        unitOfWork.ToDoListRepository.Update(listItem);

        await unitOfWork.SaveChangesAsync();

        return listItem;
    }

    public async Task DeleteToDoList(Guid guid)
    {
        var listItem = await GetToDoListByGuid(guid);

        unitOfWork.ToDoListRepository.Delete(listItem);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task<List<ToDoList>> GetAllToDoList()
    {
        return await unitOfWork.ToDoListRepository.GetAllAsync();
    }

    public Task<List<ToDoTask>> GetSampleToDoList()
    {
        List<ToDoTask> tasks =
        [
            new ToDoTask { Title = "Update time sheet" },
            new ToDoTask { Title = "Update task status in JIRA" }
        ];

        return Task.FromResult(tasks);
    }

    public async Task<ToDoList> GetToDoListByGuid(Guid guid)
    {
        Expression<Func<ToDoList, bool>> expression = x => x.ListGuid == guid;

        var items = await unitOfWork.ToDoListRepository.GetAsync(expression, [x => x.ToDoTasks]);

        var listItem = items.FirstOrDefault();

        return listItem ?? throw new InvalidDataException("No list found with the given guid");
    }
}
