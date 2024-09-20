using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;

namespace BlazeNotes.Data;

public class NoteTasksMappingRepository(BlazeAppContext context) : Repository<NoteToDoTaskMapping>(context), INoteToDoTaskMappingRepository
{
}