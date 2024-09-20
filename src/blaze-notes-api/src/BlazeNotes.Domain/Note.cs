using System.ComponentModel.DataAnnotations;

namespace BlazeNotes.Domain;

public class Note
{
    [Key]
    public int Id { get; set; }
    public Guid NoteIdentifier { get; set; } = Guid.NewGuid();

    [MaxLength(400)]
    public required string Title { get; set; } = default!;
    public required string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Note()
    {
        CreatedAt = DateTime.Now;
    }
}
