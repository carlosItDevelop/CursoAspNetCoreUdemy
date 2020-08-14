using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Mvc.Migrations
{
    public partial class UpdateSeedTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3EE387F4-ADBD-42BF-A068-022D48E99021",
                column: "ConcurrencyStamp",
                value: "ccf98833-348e-4c8f-b185-39247aac577c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F6F2A61B-4B5A-4C9C-88C9-42A473B7958D",
                columns: new[] { "ConcurrencyStamp", "DataNascimento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db8fd3c3-e67b-479f-81dd-f5d835bd3ad1", new DateTime(2020, 8, 8, 18, 21, 41, 742, DateTimeKind.Local).AddTicks(4563), "AQAAAAEAACcQAAAAEJLIuv6NtcbA7DZql3ScFzJ+DPe+Ks2vk3gOWk1OoUvbG+eK6SBaQCecGFA+mksYnA==", "30fa0103-9420-4fc5-9d8e-c95206760af3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3EE387F4-ADBD-42BF-A068-022D48E99021",
                column: "ConcurrencyStamp",
                value: "c06d5d74-a7c2-407e-8748-882f0ecb252a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F6F2A61B-4B5A-4C9C-88C9-42A473B7958D",
                columns: new[] { "ConcurrencyStamp", "DataNascimento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d615e85-a138-4a57-8442-84a72d4fcae5", new DateTime(2020, 8, 5, 22, 56, 45, 900, DateTimeKind.Local).AddTicks(7906), "AQAAAAEAACcQAAAAEOAhYjDFPuK9OJSS0nE4EH8m+73cYghEZ9hz2TuqQyecp7nbziB9MEnkVKuTaYiNkA==", "ff1cbccf-c561-42a2-b46d-7e2766bdfce2" });
        }
    }
}
