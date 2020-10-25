using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayuda",
                columns: table => new
                {
                    AyudaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departamento = table.Column<string>(type: "varchar(20)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(15)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(11)", nullable: false),
                    Modalidad = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayuda", x => x.AyudaId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(11)", nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    AyudaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Ayuda_AyudaId",
                        column: x => x.AyudaId,
                        principalTable: "Ayuda",
                        principalColumn: "AyudaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AyudaId",
                table: "Personas",
                column: "AyudaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Ayuda");
        }
    }
}
