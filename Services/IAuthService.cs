using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurkcellEsirketIntegration.Services
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync();
    }
}