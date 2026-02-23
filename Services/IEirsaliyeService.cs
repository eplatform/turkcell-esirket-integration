namespace TurkcellEsirketIntegration.Services
{
    public interface IEirsaliyeService
    {
        Task<string> SendDispatchAsync(object model);

        Task<string> GetStatusAsync(Guid id);
    }
}