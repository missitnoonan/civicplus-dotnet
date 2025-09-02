using System.ComponentModel.DataAnnotations;
using EventsApi.Attributes;

namespace EventsApi.Dto;

public class AddEventDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [DateTime]
    public string StartDate { get; set; }
    [Required]
    [DateTime]
    public string EndDate { get; set; }
}