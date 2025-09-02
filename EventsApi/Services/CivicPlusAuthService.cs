using EventsApi.Dto;
using Microsoft.Extensions.Caching.Memory;
using EventsApi.Interfaces;

namespace EventsApi.Services;

public class CivicPlusAuthService(IConfiguration configuration, IMemoryCache cache) : IAuthService
{
    public async Task<string?> GetToken()
    {
        var cachedToken = GetTokenFromCache();
        if (cachedToken != null) {
            return cachedToken;       
        }
        
        var client = new HttpClient();
        
        var authUrl = configuration["EventsApi:ApiBaseUrl"] + configuration["EventsApi:ClientId"] + "/api/auth";

        var jsonData = new {
            clientId = configuration["EventsApi:ClientId"],
            clientSecret = configuration["EventsApi:ClientSecret"]
        };

        var response = await client.PostAsJsonAsync(authUrl, jsonData);

        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
            if (responseContent != null) {
                cache.Set("access_token", responseContent.access_token);
                cache.Set("expires_at", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + responseContent.expires_in);
            
                return responseContent.access_token;
            }
        }
        
        throw new HttpRequestException();
    }
    
    private string? GetTokenFromCache()
    {
        var expiresAt = cache.Get<long>("expires_at");
        var plusOneWeek = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (24 * 60 * 60 * 7);
        
        if (expiresAt != 0 && plusOneWeek < expiresAt) {
            return cache.Get<string>("access_token");
        }
        
        return null;
    }
}