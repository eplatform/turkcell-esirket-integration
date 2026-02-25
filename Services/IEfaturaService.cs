using TurkcellEsirketIntegration.Models;

namespace TurkcellEsirketIntegration.Services;

public interface IEfaturaService
{
    Task<SendInvoiceResponse> SendEfaturaAsync(object model);

    Task<InvoiceStatusResponse> GetStatusAsync(Guid id);
}