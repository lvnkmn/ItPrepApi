using System.ComponentModel;

namespace ItPrepApi;

/*
Create a service class (e.g. ItemService) that owns an in-memory List<T>
and exposes methods like GetAll, GetById, Add, Update, Delete. Define 
an interface for it (IItemService) — this is what makes DI meaningful.
*/

class ReminderService
{
    private List<Reminder> _reminders { get; } = [];

    public List<Reminder> GetAll()
    {
        return _reminders;
    }

    public Reminder? GetById(int id)
    {
        return _reminders.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Reminder reminder)
    {
        _reminders.Add(reminder);
    }

    public bool Update(int id, Reminder reminder)
    {
        var index = _reminders.FindIndex(r => r.Id == id);
        if (index == -1)
        {
            return false;
        }

        _reminders[index] = reminder with { Id = id };
        return true;
    }

    public bool Delete(int id)
    {
        var index = _reminders.FindIndex(r => r.Id == id);
        if (index == -1)
        {
            return false;
        }

        _reminders.RemoveAt(index);
        return true;
    }
} 