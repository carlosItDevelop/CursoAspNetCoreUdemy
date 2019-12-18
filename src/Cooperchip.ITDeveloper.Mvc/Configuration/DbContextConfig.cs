using Cooperchip.ITDeveloper.Data.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cooperchip.ITDeveloper.Mvc.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ITDeveloperDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultITDeveloper")));

            return services;
        }
    }
}