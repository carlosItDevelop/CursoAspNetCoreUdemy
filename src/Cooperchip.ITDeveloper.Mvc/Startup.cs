using Cooperchip.ITDeveloper.Domain.Mensageria.EventHandlers;
using Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Mvc.Configuration;
using Cooperchip.ITDeveloper.Mvc.Data;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity.Services;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Cooperchip.ITDeveloper.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builer = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsProduction() || env.IsStaging() || env.IsDevelopment())
            {
                builer.AddUserSecrets<Startup>();
            }

            Configuration = builer.Build();

        }


        public void ConfigureServices(IServiceCollection services)
        {
            #region: Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<INotificationHandler<PacienteCadastradoEvent>, PacienteCadastradoEventHandler>();
            #endregion

            #region: KissLog
            services.AddLoggerConfig();

            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });

            #endregion

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextConfig(Configuration); // In DbContextConfig
            services.AddIdentityConfig(Configuration); // In IdentityConfig
            services.AddMvcAndRazor(); // In MvcAndRazor
            services.AddDependencyInjectConfig(Configuration); // In DependencyInjectConfig
            // Prover Suporte para Code Page (1252) (windows-1252)
            services.AddCodePageProviderNotSupportedInDotNetCoreForAnsi(); 

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();  // Obsoleto 3.1
                app.UseMigrationsEndPoint();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            var authMsgSenderOpt = new AuthMessageSenderOptions
            {
                SendGridUser = Configuration["SendGridUser"],
                SendGridKey = Configuration["SendGridKey"]
            };

            //CriaUsersAndRoles.Seed(context, userManager, roleManager).Wait();
            //app.UseMiddleware<DefaultUsersAndRolesMiddeware>();            
            //app.UseAddUserAndRoles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });

        }
    }
}
