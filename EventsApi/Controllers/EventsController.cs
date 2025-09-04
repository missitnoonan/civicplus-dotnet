using EventsApi.Dto;
using EventsApi.Entities;
using EventsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController(IEventsService eventsService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(string id)
    {
        var eventById = await eventsService.GetEvent(id);

        if (eventById == null) {
            return BadRequest("Event not found");
        }
        
        return Ok(eventById);
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GetEventsResponseDto>> GetEvents(int skip = 0, int top = 10)
    {
        var eventsResponse = await eventsService.GetEvents(skip, top);

        if (eventsResponse == null) {
            return BadRequest("No events found");       
        }
        
        return Ok(eventsResponse);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<Event>> AddEvent(AddEventDto eventData)
    {
        var newEvent = new Event {
            Title = eventData.Title,
            Description = eventData.Description,
            StartDate = eventData.StartDate,
            EndDate = eventData.EndDate
        };
        
        var eventResponse = await eventsService.AddEvent(newEvent);

        if (eventResponse == null) {
            return BadRequest("Event not added");      
        }
        
        return Ok(eventResponse);
    }
}