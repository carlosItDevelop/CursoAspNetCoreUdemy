using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class UpdMuralId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mural",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "MuralId",
                table: "Mural");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Mural",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mural",
                table: "Mural",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mural",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mural");

            migrationBuilder.AddColumn<int>(
                name: "MuralId",
                table: "Mural",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mural",
                table: "Mural",
                column: "MuralId");
        }
    }
}
