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
    public async Task<ActionResult<GetEventsResponseDto>> GetEvents()
    {
        var events = await eventsService.GetEvents();

        if (events == null) {
            return BadRequest("No events found");       
        }
        
        return Ok(events);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<Event>> AddEvent(Event postEvent)
    {
        var eventResponse = await eventsService.AddEvent(postEvent);

        if (eventResponse == null) {
            return BadRequest("Event not added");      
        }
        
        return Ok(eventResponse);
    }
}