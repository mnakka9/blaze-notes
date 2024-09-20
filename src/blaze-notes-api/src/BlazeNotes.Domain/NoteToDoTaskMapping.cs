using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeNotes.Domain;

public class NoteToDoTaskMapping
{
    [Key]
    public int Id { get; set; }
    public int NoteId { get; set; }

    [ForeignKey(nameof(NoteId))]
    public Note Note { get; set; } = default!;

    public int ToDoTaskId { get; set; }

    [ForeignKey(nameof(ToDoTaskId))]
    public ToDoTask ToDoTask { get; set; } = default!;
}