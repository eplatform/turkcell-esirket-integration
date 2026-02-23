using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using TurkcellEsirketIntegration.Settings;

namespace TurkcellEsirketIntegration.Services
{
    public class EirsaliyeService : IEirsaliyeService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IAuthService _authService;
        private readonly TurkcellSettings _settings;

        public EirsaliyeService(
            IHttpClientFactory factory,
            IAuthService authService,
            IOptions<TurkcellSettings> options)
        {
            _factory = factory;
            _authService = authService;
            _settings = options.Value;
        }

        public async Task<string> SendDispatchAsync(object model)
        {
            var client = _factory.CreateClient();
            var token = await _authService.GetTokenAsync();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync($"{_settings.BaseServiceUrl}/api/dispatch", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetStatusAsync(Guid id)
        {
            var client = _factory.CreateClient();
            var token = await _authService.GetTokenAsync();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{_settings.BaseServiceUrl}/v2/outboxdespatch/{id}/status");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}