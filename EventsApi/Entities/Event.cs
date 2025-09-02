using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;

namespace EventsApi.Entities;

public class Event
{
    public string? Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required string StartDate { get; set; }
    [Required]
    public required string EndDate { get; set; }
}