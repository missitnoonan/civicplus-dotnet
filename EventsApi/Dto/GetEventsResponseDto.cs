using EventsApi.Entities;

namespace EventsApi.Dto;

public class GetEventsResponseDto
{
    public List<Event> items { get; set; } // matching formatting expected by frontend
    public int total { get; set; }
}