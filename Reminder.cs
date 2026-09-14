namespace ItPrepApi;

public record Reminder
{
    public required int Id { get; init; }
    public required string Description { get; init; }

    public required DateTime DueDate { get; set; }
}