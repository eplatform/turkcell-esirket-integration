using TurkcellEsirketIntegration.Models;

namespace TurkcellEsirketIntegration.Services;

public interface IEirsaliyeService
{
    Task<string> SendDispatchAsync(object model);

    Task<DispatchStatusResponse> GetStatusAsync(Guid id);
}