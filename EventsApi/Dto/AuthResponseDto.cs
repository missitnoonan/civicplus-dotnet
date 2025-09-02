namespace EventsApi.Dto;

public class AuthResponseDto
{
    public required string access_token { get; set; }
    public required int expires_in { get; set; }
}