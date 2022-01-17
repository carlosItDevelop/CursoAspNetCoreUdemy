﻿using Cooperchip.ITDeveloper.CrossCutting.Auxiliar;
using Cooperchip.ITDeveloper.CrossCutting.Helpers;
using Cooperchip.ITDeveloper.Data.Repository;
using Cooperchip.ITDeveloper.Data.Repository.Abstractions;
using Cooperchip.ITDeveloper.Domain.Interfaces.Helpers;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Interfaces.ServiceContracts;
using Cooperchip.ITDeveloper.Domain.Interfaces.Services;
using Cooperchip.ITDeveloper.Mvc.Extensions.Filters;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity.Services;
using Cooperchip.ITDeveloper.Mvc.Intra;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cooperchip.ITDeveloper.Mvc.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services, 
                                                                        IConfiguration configuration)
        {


            /* Domain => Service */
            services.AddScoped<IPacienteDomainService, PacienteDomainService>();
            /* Domain => Repository */
            services.AddScoped<IRepositoryPaciente, PacienteRepository>();

            /* Data => Domain*/
            services.AddScoped<IQueryPaciente, PacienteRepository>();




            services.AddTransient<IUnitOfUpload, UnitOfUpload>();

            // =====/ Mantem o estado do contexto Http por toda a aplicação === //
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // ================================================================ //
            services.AddScoped<IUserInContext, AspNetUser>();
            services.AddScoped<IUserInAllLayer, UserInAllLayer>();
            // ================================================================ //

            // =====/ Adicionar Claims para HttpContext >> toda a Applications ================ //
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsService>();
            // ================================================================================ //

            services.AddScoped((context) => Logger.Factory.Get());
            services.AddScoped<AuditoriaIloggerFilter>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(configuration);

            return services;
        }
    }
}