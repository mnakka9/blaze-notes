using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;

namespace BlazeNotes.Data;

public class ToDoListRepository(BlazeAppContext context) : Repository<ToDoList>(context), IToDoListRepository
{
}
