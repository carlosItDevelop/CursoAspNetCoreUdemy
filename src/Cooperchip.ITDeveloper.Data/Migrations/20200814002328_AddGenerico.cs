using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class AddGenerico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Generico");
        }
    }
}
