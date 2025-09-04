using EventsApi.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace EventsApiTest;

public class CivicPlusAuthServiceTest
{
    private static readonly IMemoryCache Cache = new MemoryCache(new MemoryCacheOptions());
    private static readonly IConfiguration Configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>(){}).Build();
    
    private readonly CivicPlusAuthService _authService = new CivicPlusAuthService(Configuration, Cache);
    
    [Fact]
    public void TokenCacheTest()
    {
        _authService.SetTokenInCache("token", 2);
        Assert.Equal("token", _authService.GetTokenFromCache());
        Thread.Sleep(1100); // wait for token to get past half of its expiration time
        Assert.Null(_authService.GetTokenFromCache());
    }
}