namespace EventsApi.Entities;

public class Event
{
    public string? Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string StartDate { get; set; }
    public required string EndDate { get; set; }
}