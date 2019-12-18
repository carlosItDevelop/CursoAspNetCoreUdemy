using Cooperchip.ITDeveloper.Mvc.Extentions.Filters;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cooperchip.ITDeveloper.Mvc.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((context) => Logger.Factory.Get());
            services.AddScoped<AuditoriaIloggerFilter>();

            return services;
        }
    }
}