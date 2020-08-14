using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Mvc.Migrations
{
    public partial class AddUserAndRoleWithExtensionMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3EE387F4-ADBD-42BF-A068-022D48E99021", "c06d5d74-a7c2-407e-8748-882f0ecb252a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Apelido", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "F6F2A61B-4B5A-4C9C-88C9-42A473B7958D", 0, "rfraca", "4d615e85-a138-4a57-8442-84a72d4fcae5", new DateTime(2020, 8, 5, 22, 56, 45, 900, DateTimeKind.Local).AddTicks(7906), "rfranca@gmail.com", true, false, null, "Roberto França", "RFRANCA@GMAIL.COM", "RFRANCA@GMAIL.COM", "AQAAAAEAACcQAAAAEOAhYjDFPuK9OJSS0nE4EH8m+73cYghEZ9hz2TuqQyecp7nbziB9MEnkVKuTaYiNkA==", null, false, "ff1cbccf-c561-42a2-b46d-7e2766bdfce2", false, "rfranca@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "F6F2A61B-4B5A-4C9C-88C9-42A473B7958D", "3EE387F4-ADBD-42BF-A068-022D48E99021" });

 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
