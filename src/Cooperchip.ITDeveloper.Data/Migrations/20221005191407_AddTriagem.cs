using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class AddTriagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Triagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePaciente = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    DataNotificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Triagem");
        }
    }
}
