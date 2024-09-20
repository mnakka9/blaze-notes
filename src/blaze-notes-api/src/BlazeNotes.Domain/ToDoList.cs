using System.ComponentModel.DataAnnotations;

namespace BlazeNotes.Domain;

public class ToDoList
{
    [Key]
    public int Id { get; set; }

    public Guid ListGuid { get; set; } = Guid.NewGuid();

    public ICollection<ToDoTask> ToDoTasks { get; set; } = [];
}
