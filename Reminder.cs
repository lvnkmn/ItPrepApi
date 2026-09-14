namespace ItPrepApi;

public class Reminder
{
    public required int Id { get; init; }

    public required String Description { get; set; }

    public required DateTime DueDate { get; set; }
}