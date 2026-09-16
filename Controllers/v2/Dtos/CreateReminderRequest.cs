namespace ItPrepApi.Controllers.v2.Dtos;
public record CreateReminderRequest
{
    public required string Description { get; init; }
    public required DateTime DueDate { get; init; }
}