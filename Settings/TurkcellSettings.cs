using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurkcellEsirketIntegration.Settings
{
    public class TurkcellSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string AuthUrl { get; set; }
        public string BaseServiceUrl { get; set; }
    }
}