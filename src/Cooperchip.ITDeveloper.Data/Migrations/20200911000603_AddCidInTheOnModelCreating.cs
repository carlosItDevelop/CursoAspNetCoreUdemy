using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class AddCidInTheOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cid",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CidInternalId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cid", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cid");
        }
    }
}
