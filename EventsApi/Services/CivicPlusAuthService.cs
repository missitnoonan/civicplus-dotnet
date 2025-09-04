using EventsApi.Dto;
using Microsoft.Extensions.Caching.Memory;
using EventsApi.Interfaces;

namespace EventsApi.Services;

public class CivicPlusAuthService(IConfiguration configuration, IMemoryCache cache) : IAuthService
{
    private const string TokenCacheKey = "token";
    private const string TokenExpiresAtCacheKey = "tokenExpiresAt";
    private const string TokenDuration = "tokenDuration";
    
    public async Task<string?> GetToken()
    {
        var cachedToken = GetTokenFromCache();
        if (cachedToken != null) {
            return cachedToken;       
        }
        
        var client = new HttpClient();
        var baseUrl = configuration["EventsApi:ApiBaseUrl"];
        var clientId = configuration["EventsApi:ClientId"];
        var clientSecret = configuration["EventsApi:ClientSecret"];

        if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret)) {
            throw new SystemException("Missing configuration for CivicPlus API");
        }
        
        var authUrl = baseUrl + clientId + "/api/auth";

        var jsonData = new {
            clientId,
            clientSecret,
        };

        var response = await client.PostAsJsonAsync(authUrl, jsonData);

        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
            if (responseContent != null) {
                SetTokenInCache(responseContent.access_token, responseContent.expires_in);
            
                return responseContent.access_token;
            }
        }
        
        throw new SystemException("Failed to get token from CivicPlus API");
    }
    
    internal string? GetTokenFromCache() // internal for testing
    {
        var expiresAt = cache.Get<long>(TokenExpiresAtCacheKey);
        var duration = cache.Get<int>(TokenDuration);
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var plusHalfExpiresIn = now + (duration / 2);
        
        if (expiresAt != 0 && plusHalfExpiresIn < expiresAt) {
            return cache.Get<string>(TokenCacheKey);
        }
        
        return null;
    }

    internal void SetTokenInCache(string token, int expiresIn) // internal for testing
    {
        cache.Set(TokenCacheKey, token);
        cache.Set(TokenDuration, expiresIn);
        cache.Set(TokenExpiresAtCacheKey, DateTimeOffset.UtcNow.ToUnixTimeSeconds() + expiresIn);
    }
}