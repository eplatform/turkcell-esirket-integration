using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurkcellEsirketIntegration.Settings;

public class IntegrationAuthSettings
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string AuthUrl { get; set; } = default!;
}