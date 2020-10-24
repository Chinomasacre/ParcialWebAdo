using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayudas",
                columns: table => new
                {
                    personaIdentificacion = table.Column<string>(type: "varchar(11)", nullable: false),
                    Departamento = table.Column<string>(type: "varchar(20)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(15)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(11)", nullable: false),
                    Modalidad = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudas", x => x.personaIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(11)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayudas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
