using System.ComponentModel.DataAnnotations;
using EventsApi.Attributes;

namespace EventsApi.Dto;

public class AddEventDto
{
    [Required]
    public string Title { get; set; } // not setting as required for better error message from annotation
    [Required]
    public string Description { get; set; }
    [Required]
    [DateTime]
    public string StartDate { get; set; }
    [Required]
    [DateTime]
    public string EndDate { get; set; }
}