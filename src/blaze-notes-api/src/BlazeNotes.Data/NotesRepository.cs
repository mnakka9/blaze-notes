using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;

namespace BlazeNotes.Data;

public class NotesRepository(BlazeAppContext context) : Repository<Note>(context), INotesRepository
{
}
