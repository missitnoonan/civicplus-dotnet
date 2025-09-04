using System.Web;
using EventsApi.Dto;
using EventsApi.Entities;
using EventsApi.Interfaces;

namespace EventsApi.Services;

public class CivicPlusEventsService(IConfiguration configuration, IAuthService authService, IHttpClientFactory httpClientFactory) : IEventsService
{
    private IConfiguration _configuration = configuration;
    private IHttpClientFactory _httpClientFactory = httpClientFactory;
    
    public async Task<Event?> GetEvent(string id)
    {
        var client = await GetClient();
        
        var response = await client.GetAsync(GetApiUrl() + "Events/" + id);

        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<Event>();
        
            return responseContent;
        }
        
        return null;
    }
    
    public async Task<GetEventsResponseDto?> GetEvents(int skip = 0, int top = 10)
    {
        var client = await GetClient();
        
        var builder = new UriBuilder(GetApiUrl() + "Events");
        var query = HttpUtility.ParseQueryString("");
        query["$skip"] = skip.ToString();
        query["$top"] = top.ToString();

        builder.Query = query.ToString();
        
        var response = await client.GetAsync(builder.ToString());
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<GetEventsResponseDto>();
        
            return responseContent;
        }

        return null;
    }

    public async Task<Event?> AddEvent(Event eventDto)
    {
        var client = await GetClient();
        
        var response = await client.PostAsJsonAsync(GetApiUrl() + "Events", eventDto);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<Event>();
        
            return responseContent;
        }
        
        return null;
    }

    private string GetApiUrl()
    {
        var baseUrl = _configuration["EventsApi:ApiBaseUrl"];
        var clientId = _configuration["EventsApi:ClientId"];
        if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(clientId)) {
            throw new SystemException();
        }
        
        return baseUrl + clientId + "/api/";
    }
    
    private async Task<HttpClient> GetClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + await authService.GetToken());
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        
        return client;   
    }
}