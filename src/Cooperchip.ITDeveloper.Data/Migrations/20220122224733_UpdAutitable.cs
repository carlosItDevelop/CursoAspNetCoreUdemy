using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class UpdAutitable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Medicamento");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Generico");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "EstadoPaciente");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Cid");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Paciente",
                newName: "DataUltimaModificacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInclusao",
                table: "Paciente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Paciente",
                type: "varchar(90)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaModificacao",
                table: "Paciente",
                type: "varchar(90)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInclusao",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaModificacao",
                table: "Paciente");

            migrationBuilder.RenameColumn(
                name: "DataUltimaModificacao",
                table: "Paciente",
                newName: "DataCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Medicamento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Generico",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "EstadoPaciente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Cid",
                type: "datetime2",
                nullable: true);
        }
    }
}
