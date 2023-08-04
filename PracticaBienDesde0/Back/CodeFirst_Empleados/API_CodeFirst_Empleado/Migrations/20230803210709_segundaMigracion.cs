using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CodeFirst_Empleado.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Empleado_JefeId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_JefeId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdJefe",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "JefeId",
                table: "Empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdJefe",
                table: "Empleado",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JefeId",
                table: "Empleado",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_JefeId",
                table: "Empleado",
                column: "JefeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Empleado_JefeId",
                table: "Empleado",
                column: "JefeId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
