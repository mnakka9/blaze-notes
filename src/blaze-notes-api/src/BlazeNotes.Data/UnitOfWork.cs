using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazeNotes.Data;

public class UnitOfWork(
    BlazeAppContext context,
    IToDoListRepository toDoListRepository,
    IToDoTasksRepository toDoTasksRepository,
    INotesRepository notesRepository,
    INoteToDoTaskMappingRepository noteToDoTaskMappingRepository
) : IUnitOfWork
{
    public IToDoListRepository ToDoListRepository => toDoListRepository;

    public IToDoTasksRepository ToDoTasksRepository => toDoTasksRepository;

    public INotesRepository NotesRepository => notesRepository;

    public INoteToDoTaskMappingRepository NoteToDoTaskMappingRepository =>
        noteToDoTaskMappingRepository;

    public async Task CommitTransactionAsync()
    {
        await context.Database.CommitTransactionAsync();
    }

    public async Task<IDbContextTransaction> GetTransactionAsync()
    {
        return await context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
