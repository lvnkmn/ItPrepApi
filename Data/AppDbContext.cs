using ItPrepApi;
using Microsoft.EntityFrameworkCore;
namespace ItPrepApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<Reminder> Reminders { get; set; }
}