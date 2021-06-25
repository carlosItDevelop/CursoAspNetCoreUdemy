
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.ExtensionsMethods
{
    public static class ModelBuilderExtension
    {

        const string NOMECOMPLETO = "Roberto França";
        const string APELIDO = "rfraca";
        //var datanascimento = DateTime.Now;
        const string EMAIL = "rfranca@gmail.com";
        const string PASSWORD = "Admin@123"; // Todo: Inportante seguir as regras
        const string ROLERNAME = "Admin";
        const string USERNAME = EMAIL;

        const string USERID = "F6F2A61B-4B5A-4C9C-88C9-42A473B7958D";
        const string ROLEID = "3EE387F4-ADBD-42BF-A068-022D48E99021";

        public static ModelBuilder AddUserAndRole(this ModelBuilder builder)
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
                    DataNascimento = DateTime.Now,
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

            return builder;
        }

        public static ModelBuilder AddGenericos(this ModelBuilder builder)
        {

            var k = 0;
            string line;

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var csvPath = Path.Combine(outPutDirectory, "Csv\\Generico.CSV");
            string filePath = new Uri(csvPath).LocalPath;

            using(var fs = File.OpenRead(filePath))
            using(var reader = new StreamReader(fs))

                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    var codigo = parts[0];
                    var generico = parts[1];
                    if (k > 0)
                    {
                        builder.Entity<Generico>().HasData(                             
                            new Generico
                            {
                                //Id = Guid.NewGuid(),
                                Codigo = Convert.ToInt32(codigo),
                                Nome = generico
                            });
                    }
                    k++;
                }

            return builder;
        }

        
    }
}
