namespace ItPrepApi;

public interface IReminderService
{
    Task<List<Reminder>> GetAllAsync();
    Task<Reminder?> GetByIdAsync(int id);
    Task AddAsync(Reminder reminder);
    Task<bool> UpdateAsync(int id, Reminder reminder);
    Task<bool> DeleteAsync(int id);
}
