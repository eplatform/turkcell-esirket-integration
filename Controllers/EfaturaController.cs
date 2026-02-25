using Microsoft.AspNetCore.Mvc;
using TurkcellEsirketIntegration.Models;
using TurkcellEsirketIntegration.Services;

namespace TurkcellEsirketIntegration.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EfaturaController : ControllerBase
    {
        private readonly IEfaturaService service;
        private readonly ILogger<EfaturaController> logger;

        public EfaturaController(IEfaturaService service,
        ILogger<EfaturaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }
        /// <summary>
        /// Sample bir fatura gönderme işlemi. Gerçek uygulamada, bu endpoint'e gelen veriyi kullanarak bir fatura oluşturmanız gerekecektir.
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendInvoice()
        {
            var sampleInvoice = SampleUblBuilder.CreateSampleInvoice();
            var result = await service.SendEfaturaAsync(sampleInvoice);
            return Ok(result);
        }

        /// <summary>
        /// Fatura durumunu sorgulamak için kullanılan endpoint. Gerçek uygulamada, bu endpoint'e bir fatura ID'si göndererek o faturanın durumunu sorgulayabilirsiniz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("status")]
        public async Task<InvoiceStatusResponse> GetStatus([FromQuery] Guid id) => await service.GetStatusAsync(id);
    }
}