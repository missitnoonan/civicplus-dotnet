using System.ComponentModel.DataAnnotations;

namespace EventsApi.Attributes;

public class DateTimeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime tempDate;
        if (DateTime.TryParse(value.ToString(), out tempDate)) {
            return ValidationResult.Success;
        }
        
        return new ValidationResult("Invalid date format");
    }
}