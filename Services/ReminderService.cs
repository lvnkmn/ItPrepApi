using System.ComponentModel;
using ItPrepApi.Data;

namespace ItPrepApi;

public class ReminderService: IReminderService
{
    public ReminderService(AppDbContext context)
    {
        _context = context;
    }

    private readonly AppDbContext _context;

    public List<Reminder> GetAll()
    {
        return _context.Reminders.ToList();
    }

    public Reminder? GetById(int id)
    {
        return _context.Reminders.Find(id);
    }

    public void Add(Reminder reminder)
    {
        _context.Reminders.Add(reminder);
        _context.SaveChanges();
    }

    public bool Update(int id, Reminder reminder)
    {
        var existing = _context.Reminders.Find(id);
        if (existing is null) return false;

        _context.Entry(existing).CurrentValues.SetValues(reminder with { Id = id });
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Reminder? existing = _context.Reminders.Find(id);
        if(existing == null)
        {
            return false;
        }
        _context.Reminders.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}