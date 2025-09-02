using EventsApi.Entities;

namespace EventsApi.Dto;

public class GetEventsResponseDto
{
    public List<Event> items { get; set; }
    public int total { get; set; }
}