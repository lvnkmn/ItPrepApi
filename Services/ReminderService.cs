using System.ComponentModel;

namespace ItPrepApi;

class ReminderService: IReminderService
{
    private readonly List<Reminder> _reminders = [];

    public List<Reminder> GetAll()
    {
        return _reminders.ToList();
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