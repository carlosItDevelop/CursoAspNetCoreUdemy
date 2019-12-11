using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class AddMovimentoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    TipoMovimentoPaciente = table.Column<int>(nullable: false),
                    TipoEntradaPaciente = table.Column<int>(nullable: false),
                    TipoSaidaPaciente = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoPaciente_PacienteId",
                table: "MovimentoPaciente",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentoPaciente");
        }
    }
}
