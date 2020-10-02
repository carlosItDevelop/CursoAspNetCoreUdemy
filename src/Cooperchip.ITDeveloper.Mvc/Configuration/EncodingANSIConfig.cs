using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Configuration
{
    public static class EncodingANSIConfig
    {
        public static IServiceCollection AddCodePageProviderNotSupportedInDotNetCoreForAnsi(this IServiceCollection services)
        {
            // Fornece acesso a um provdor de codificação para páginas de código
            // que, de outra forma, estão disponíveis apenas no .Net Framework para Desktop
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return services;
        }
    }
}
