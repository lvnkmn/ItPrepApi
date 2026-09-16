namespace ItPrepApi;

public interface IReminderService
{
    Task<List<Reminder>> GetAllAsync();
    Task<Reminder?> GetByIdAsync(Guid id);
    Task AddAsync(Reminder reminder);
    Task<bool> UpdateAsync(Guid id, Reminder reminder);
    Task<bool> DeleteAsync(Guid id);
}
