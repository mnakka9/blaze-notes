using Microsoft.EntityFrameworkCore.Storage;

namespace BlazeNotes.Data.Interfaces;

public interface IUnitOfWork
{
    IToDoListRepository ToDoListRepository { get; }

    IToDoTasksRepository ToDoTasksRepository { get; }

    INotesRepository NotesRepository { get; }

    INoteToDoTaskMappingRepository NoteToDoTaskMappingRepository { get; }

    void SaveChanges();

    Task<int> SaveChangesAsync();

    Task<IDbContextTransaction> GetTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransaction();
}
