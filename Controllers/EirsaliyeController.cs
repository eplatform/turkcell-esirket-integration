using Microsoft.AspNetCore.Mvc;
using TurkcellEsirketIntegration.Services;

namespace TurkcellEsirketIntegration.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EirsaliyeController : ControllerBase
    {
        private readonly IEirsaliyeService _service;
        private readonly ILogger<EirsaliyeController> _logger;

        public EirsaliyeController(IEirsaliyeService service,
        ILogger<EirsaliyeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatus([FromQuery] Guid id)
        {
            var result = await _service.GetStatusAsync(id);
            return Ok(result);
        }
    }
}