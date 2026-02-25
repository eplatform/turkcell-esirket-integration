using System.Net.Http.Headers;
using TurkcellEsirketIntegration.Models;

namespace TurkcellEsirketIntegration.Services;

public class EfaturaService : IEfaturaService
{
    private readonly HttpClient client;
    private readonly IAuthService authService;

    public EfaturaService(
        HttpClient client,
        IAuthService authService)
    {
        this.client = client;
        this.authService = authService;
    }

    public async Task<SendInvoiceResponse> SendEfaturaAsync(object model)
    {
        var token = await authService.GetTokenAsync();

        using var request =
               new HttpRequestMessage(HttpMethod.Post,
               $"/v1/outboxinvoice/create");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Content = JsonContent.Create(model);

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            // StatusCode + Body yazdırıldı
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Hata Kodu: {(int)response.StatusCode} ({response.StatusCode})");
            Console.WriteLine($"Hata Detayı: {content}");

            // Hata fırlatıldı
            throw new ApplicationException($"API Hatası: {(int)response.StatusCode} - {content}");
        }
        return await response.Content.ReadFromJsonAsync<SendInvoiceResponse>();
    }

    public async Task<InvoiceStatusResponse> GetStatusAsync(Guid id)
    {
        var token = await authService.GetTokenAsync();

        using var request =
               new HttpRequestMessage(HttpMethod.Get,
               $"/v2/outboxinvoice/{id}/status");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<InvoiceStatusResponse>();
    }

}