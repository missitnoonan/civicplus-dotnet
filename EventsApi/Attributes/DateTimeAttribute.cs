using System.ComponentModel.DataAnnotations;

namespace EventsApi.Attributes;

public class DateTimeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        DateTime tempDate;
        // null is covered by required attribute
        if (value == null || DateTime.TryParse(value?.ToString(), out tempDate)) {
            return ValidationResult.Success;
        }
        
        return new ValidationResult($"The {validationContext.DisplayName} field is not a valid date.");
    }
}