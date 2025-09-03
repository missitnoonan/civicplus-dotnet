using EventsApi.Services;
using Microsoft.Extensions.Caching.Memory;

namespace EventsApiTest;

public class CivicPlusAuthServiceTest
{
    private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    private CivicPlusAuthService _authService = new CivicPlusAuthService(null, _cache);
    
    [Fact]
    public void TokenCacheTest()
    {
        _authService.SetTokenInCache("token", 2);
        Assert.Equal("token", _authService.GetTokenFromCache());
        Thread.Sleep(1100); // wait for token to get past half of its expiration time
        Assert.Null(_authService.GetTokenFromCache());
    }
}