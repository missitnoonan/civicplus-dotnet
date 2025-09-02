namespace EventsApi.Interfaces;

public interface IAuthService
{
    public Task<string?> GetToken();
}