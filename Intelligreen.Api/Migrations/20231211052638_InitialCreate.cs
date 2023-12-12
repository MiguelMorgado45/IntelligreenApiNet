using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligreen.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    DispositivoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    CircuitoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.DispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    PlantaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCientifico = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Dificultad = table.Column<int>(type: "INTEGER", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: false),
                    MinTempAmb = table.Column<double>(type: "REAL", nullable: false),
                    MaxTempAmb = table.Column<double>(type: "REAL", nullable: false),
                    MinHumedadAmb = table.Column<double>(type: "REAL", nullable: false),
                    MaxHumedadAmb = table.Column<double>(type: "REAL", nullable: false),
                    MinHumedadSuelo = table.Column<double>(type: "REAL", nullable: false),
                    MaxHumedadSuelo = table.Column<double>(type: "REAL", nullable: false),
                    Cuidados = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.PlantaId);
                });

            migrationBuilder.CreateTable(
                name: "PlantasUsuarios",
                columns: table => new
                {
                    PlantaUsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Apodo = table.Column<string>(type: "TEXT", nullable: false),
                    PlantaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DispositivoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantasUsuarios", x => x.PlantaUsuarioId);
                    table.ForeignKey(
                        name: "FK_PlantasUsuarios_Dispositivos_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivos",
                        principalColumn: "DispositivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantasUsuarios_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "PlantaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantasUsuarios_DispositivoId",
                table: "PlantasUsuarios",
                column: "DispositivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantasUsuarios_PlantaId",
                table: "PlantasUsuarios",
                column: "PlantaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantasUsuarios");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Plantas");
        }
    }
}
