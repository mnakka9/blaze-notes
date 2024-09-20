using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;

namespace BlazeNotes.Data;

public class ToDoTasksRepository(BlazeAppContext context) : Repository<ToDoTask>(context), IToDoTasksRepository
{
}