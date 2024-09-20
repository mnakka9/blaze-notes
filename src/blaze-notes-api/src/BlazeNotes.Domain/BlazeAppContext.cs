// Ignore Spelling: App

using Microsoft.EntityFrameworkCore;

namespace BlazeNotes.Domain;

public class BlazeAppContext(DbContextOptions<BlazeAppContext> options) : DbContext(options)
{
    public DbSet<ToDoTask> ToDoTasks { get; set; }

    public DbSet<Note> Notes { get; set; }

    public DbSet<ToDoList> ToDoList { get; set; }

    public DbSet<NoteToDoTaskMapping> NoteToDoTaskMappings { get; set; }
}
