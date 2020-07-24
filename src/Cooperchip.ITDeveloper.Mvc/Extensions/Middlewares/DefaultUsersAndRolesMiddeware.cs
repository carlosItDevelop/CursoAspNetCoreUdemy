using Cooperchip.ITDeveloper.Mvc.Data;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.Middlewares
{
    public class DefaultUsersAndRolesMiddeware
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DefaultUsersAndRolesMiddeware(RequestDelegate next, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _next = next;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InvokeAsync(HttpContext _context)
        {
            Debug.WriteLine("RODANDO O PROCESSO DE VERIFICAÇÃO DE USUÁRIO E PAPEIS EXISTENTES. SE NÃO HOUVER CRIAR!");
            // Executar nossa rotina de Criação de User and Role, só agora através de um Middleware
            await _next(_context);
            Debug.WriteLine("PROCESSO DE VERIFICAÇÃO DE USUÁRIO E PAPEIS TERMINADO!");

        }

    }

}
