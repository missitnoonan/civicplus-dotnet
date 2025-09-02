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
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + await authService.GetToken());
        
        var response = await client.GetAsync(GetApiUrl() + "Events/" + id);

        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<Event>();
        
            return responseContent;
        }
        
        return null;
    }
    
    public async Task<GetEventsResponseDto?> GetEvents(int skip = 0, int top = 10)
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + await authService.GetToken());
        
        var builder = new UriBuilder(GetApiUrl() + "Events");
        var query = HttpUtility.ParseQueryString("");
        query["$skip"] = skip.ToString();
        query["$top"] = top.ToString();

        builder.Query = query.ToString();
        var uir = builder.ToString();
        
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
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + await authService.GetToken());
        
        var response = await client.PostAsJsonAsync(GetApiUrl() + "Events", eventDto);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadFromJsonAsync<Event>();
        
            return responseContent;
        }
        
        return null;
    }

    public string GetApiUrl()
    {
        return _configuration["EventsApi:ApiBaseUrl"] + _configuration["EventsApi:ClientId"] + "/api/";
    }
}