using System.ComponentModel;
using ItPrepApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ItPrepApi;

public class ReminderService: IReminderService
{
    public ReminderService(AppDbContext context)
    {
        _context = context;
    }

    private readonly AppDbContext _context;

    public async Task<List<Reminder>> GetAllAsync()
    {
        return await _context.Reminders.ToListAsync();
    }

    public async Task<Reminder?> GetByIdAsync(int id)
    {
        return await _context.Reminders.FindAsync(id);
    }

    public async Task AddAsync(Reminder reminder)
    {
        await _context.Reminders.AddAsync(reminder);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(int id, Reminder reminder)
    {
        var existing = await _context.Reminders.FindAsync(id);
        if (existing is null) return false;

        _context.Entry(existing).CurrentValues.SetValues(reminder with { Id = id });
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Reminder? existing = await _context.Reminders.FindAsync(id);
        if(existing == null)
        {
            return false;
        }
        _context.Reminders.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}