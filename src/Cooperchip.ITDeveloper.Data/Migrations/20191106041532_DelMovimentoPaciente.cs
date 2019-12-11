using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class DelMovimentoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentoPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataMovimento = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    PacienteId = table.Column<Guid>(nullable: false),
                    TipoEntradaPaciente = table.Column<int>(nullable: false),
                    TipoMovimentoPaciente = table.Column<int>(nullable: false),
                    TipoSaidaPaciente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoPaciente_PacienteId",
                table: "MovimentoPaciente",
                column: "PacienteId");
        }
    }
}
