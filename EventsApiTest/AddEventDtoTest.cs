using System.ComponentModel.DataAnnotations;
using EventsApi.Dto;
using EventsApi.Services;
using Microsoft.Extensions.Caching.Memory;

namespace EventsApiTest;

public class AddEventDtoTest
{
    [Fact]
    public void EndDateIsRequiredTest()
    {
        var dto = new AddEventDto() {
            Title = "Test",
            Description = "Test",
            StartDate = "2022-01-01",
        };

        var validations = ValidateModel(dto);

        Assert.NotEmpty(validations);
        Assert.Contains(validations, x => x.MemberNames.Contains("EndDate"));
        Assert.Contains(validations, x => x.ErrorMessage == "The EndDate field is required.");
    }

    [Fact]
    public void EndDateMustBeADateTest()
    {
        var dto = new AddEventDto() {
            Title = "Test",
            Description = "Test",
            StartDate = "2022-01-01",
            EndDate = "not a date"
        };

        var validations = ValidateModel(dto);

        Assert.NotEmpty(validations);
        Assert.Contains(validations, x => x.ErrorMessage == "Invalid date format");
    }

    // stolen from https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);
       
        return validationResults;
    }
}