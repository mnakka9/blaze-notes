using System.ComponentModel.DataAnnotations;

namespace BlazeNotes.Domain;

public class ToDoTask
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Title { get; set; } = default!;
    [MaxLength(5000)]
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public PriorityLevel Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public ToDoTask()
    {
        CreatedAt = DateTime.Now;
        IsCompleted = false;
        Priority = PriorityLevel.Medium;
    }
}

public enum PriorityLevel
{
    Low,
    Medium,
    High
}