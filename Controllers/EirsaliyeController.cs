using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using TurkcellEsirketIntegration.Models;
using TurkcellEsirketIntegration.Services;

namespace TurkcellEsirketIntegration.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EirsaliyeController : ControllerBase
    {
        private readonly IEirsaliyeService service;
        private readonly ILogger<EirsaliyeController> logger;

        public EirsaliyeController(IEirsaliyeService service,
        ILogger<EirsaliyeController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// İrsaliye durumunu sorgulamak için kullanılan endpoint. Gerçek uygulamada, bu endpoint'e bir fatura ID'si göndererek o faturanın durumunu sorgulayabilirsiniz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("status")]
        public async Task<DispatchStatusResponse> GetStatus([FromQuery] Guid id) => await service.GetStatusAsync(id);

    }
}