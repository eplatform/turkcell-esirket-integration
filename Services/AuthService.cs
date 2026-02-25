using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using TurkcellEsirketIntegration.Settings;

namespace TurkcellEsirketIntegration.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient client;
        private readonly IMemoryCache _cache;
        private readonly IntegrationAuthSettings _settings;
        private const string CacheKey = "TurkcellToken";

        public AuthService(
            HttpClient httpClient,
            IMemoryCache cache,
            IOptions<IntegrationAuthSettings> options)
        {
            client = httpClient;
            _cache = cache;
            _settings = options.Value;
        }

        public async Task<string> GetTokenAsync()
        {
            if (_cache.TryGetValue(CacheKey, out string cachedToken))
                return cachedToken;

            var url = _settings.AuthUrl;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("username", _settings.Username),
                new KeyValuePair<string,string>("password", _settings.Password),
                new KeyValuePair<string,string>("client_id", _settings.ClientId),
            });

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            string token = root.GetProperty("access_token").GetString();
            int expiresIn = int.Parse(root.GetProperty("expires_in").GetString());

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expiresIn - 60)
            };
            _cache.Set(CacheKey, token, cacheOptions);

            return token;
        }
    }
}