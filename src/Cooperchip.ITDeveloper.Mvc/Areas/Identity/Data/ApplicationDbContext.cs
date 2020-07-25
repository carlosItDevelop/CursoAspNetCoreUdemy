
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cooperchip.ITDeveloper.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        const string NOMECOMPLETO = "Carlos Santos";
        const string APELIDO = "carlos";
        DateTime datanascimento = DateTime.Now;
        const string EMAIL = "csantos@gmail.com";
        const string PASSWORD = "Admin@123"; // Todo: Inportante seguir as regras
        const string ROLERNAME = "Convidado";
        const string USERNAME = EMAIL;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        const string ROLEID = "3EE387F4-ADBD-42BF-A068-022D48E99145";
        const string USERID = "F6F2A61B-4B5A-4C9C-88C9-42A473B7987C";

                                

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLEID,
                    Name = ROLERNAME,
                    NormalizedName = ROLERNAME.ToUpper()
                }
            );

            var phash = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = USERID,
                    Apelido = APELIDO,
                    NomeCompleto = NOMECOMPLETO,
                    DataNascimento = datanascimento,
                    Email = EMAIL,
                    NormalizedEmail = EMAIL.ToUpper(),
                    UserName = USERNAME,
                    NormalizedUserName = USERNAME.ToUpper(),
                    PasswordHash = phash.HashPassword(null, PASSWORD),
                    EmailConfirmed = true
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLEID,
                    UserId = USERID
                });

            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
