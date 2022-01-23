using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class UpdAutitableInEstadoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInclusao",
                table: "EstadoPaciente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaModificacao",
                table: "EstadoPaciente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "EstadoPaciente",
                type: "varchar(90)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaModificacao",
                table: "EstadoPaciente",
                type: "varchar(90)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInclusao",
                table: "EstadoPaciente");

            migrationBuilder.DropColumn(
                name: "DataUltimaModificacao",
                table: "EstadoPaciente");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "EstadoPaciente");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaModificacao",
                table: "EstadoPaciente");
        }
    }
}
