using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Mvc.Migrations
{
    public partial class AddNewUsrAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3EE387F4-ADBD-42BF-A068-022D48E99145", "fbc1a1ad-8865-4694-88bc-b4980ebfc521", "Convidado", "CONVIDADO" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Apelido", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "F6F2A61B-4B5A-4C9C-88C9-42A473B7987C", 0, "carlos", "5cf046fa-2eda-466b-85a2-ae33d59fc9fc", new DateTime(2020, 7, 25, 1, 13, 34, 690, DateTimeKind.Local).AddTicks(4868), "csantos@gmail.com", true, false, null, "Carlos Santos", "CSANTOS@GMAIL.COM", "CSANTOS@GMAIL.COM", "AQAAAAEAACcQAAAAEDO33S7V54NPh+TiusG1HhUYsOypa1qimbhZ7D4ZJzhd9ZUaC5nDjEyOHToPr8VPvA==", null, false, "0568f543-6335-4665-b909-e0846a2e3984", false, "csantos@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "F6F2A61B-4B5A-4C9C-88C9-42A473B7987C", "3EE387F4-ADBD-42BF-A068-022D48E99145" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "F6F2A61B-4B5A-4C9C-88C9-42A473B7987C", "3EE387F4-ADBD-42BF-A068-022D48E99145" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3EE387F4-ADBD-42BF-A068-022D48E99145");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F6F2A61B-4B5A-4C9C-88C9-42A473B7987C");
        }
    }
}
