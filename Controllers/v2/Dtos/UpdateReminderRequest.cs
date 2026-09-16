namespace ItPrepApi.Controllers.v2.Dtos;

public record UpdateReminderRequest
{
    public required string Description { get; init; }
    public required DateTime DueDate { get; init; }
}