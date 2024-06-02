using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriscilaZunigaWebBookBites.Migrations
{
    /// <inheritdoc />
    public partial class NuevaBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PZLibro",
                columns: table => new
                {
                    PZLibroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PZTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PZAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PZVolumen = table.Column<int>(type: "int", nullable: false),
                    PZPrecio = table.Column<float>(type: "real", nullable: false),
                    PZNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PZLibro", x => x.PZLibroID);
                });

            migrationBuilder.CreateTable(
                name: "PZCopia",
                columns: table => new
                {
                    PZCopiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PZCantidad = table.Column<int>(type: "int", nullable: false),
                    PZColor = table.Column<bool>(type: "bit", nullable: false),
                    PZFormato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PZFechaCopia = table.Column<DateOnly>(type: "date", nullable: false),
                    PZLibroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PZCopia", x => x.PZCopiaID);
                    table.ForeignKey(
                        name: "FK_PZCopia_PZLibro_PZLibroID",
                        column: x => x.PZLibroID,
                        principalTable: "PZLibro",
                        principalColumn: "PZLibroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PZCopia_PZLibroID",
                table: "PZCopia",
                column: "PZLibroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PZCopia");

            migrationBuilder.DropTable(
                name: "PZLibro");
        }
    }
}
