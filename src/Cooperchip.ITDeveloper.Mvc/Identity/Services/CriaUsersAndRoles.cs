using System;
using System.Threading.Tasks;
using Cooperchip.ITDeveloper.Mvc.Data;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.ITDeveloper.Mvc.Identity.Services
{
    public static class CriaUsersAndRoles
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            const string nomecompleto = "Maria de Jesus";
            const string apelido = "Mary";
            var datanascimento = DateTime.Now;
            const string email = "mary@gmail.com";
            const string password = "Admin@123"; // Todo: Inportante seguir as regras
            const string roleName = "Admin";
            const string username = email;


            context.Database.Migrate();

            // Todo: Cuidado!!! [ context.Database.EnsureCreated() ]  Garante a existência do banco de dados para o contexto.Se existir, nenhuma ação será tomada. Se não existir, o banco de dados e todo o seu esquema serão criados. se o banco de dados existir, não será feito nenhum esforço para garantir que seja compatível com o modelo para este contexto. Observe que essa API não usa migrações para criar o banco de dados.Além disso, o banco de dados criado não pode ser atualizado posteriormente com migrações. Se você estiver direcionando um banco de dados de relações e usando migrações, poderá usar o método DbContext.Database.Migrate() para garantir que o banco de dados seja criado e todas as migrações sejam aplicadas.


            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new ApplicationUser
                {
                    Apelido = apelido,
                    NomeCompleto = nomecompleto,
                    DataNascimento = datanascimento,
                    UserName = username,
                    Email = email,
                    PhoneNumber = "21987861071",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, roleName);
                }

            }

        }
    }
}