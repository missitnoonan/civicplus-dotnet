using EventsApi.Dto;
using EventsApi.Entities;

namespace EventsApi.Interfaces;

public interface IEventsService
{
    public Task<Event?> GetEvent(string id);
    public Task<GetEventsResponseDto?> GetEvents();
    public Task<Event?> AddEvent(Event eventData);
}