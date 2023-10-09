using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parcial1.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipoConsole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoConsole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    GanoEstaFecha = table.Column<bool>(type: "INTEGER", nullable: false),
                    PrecioEntrada = table.Column<decimal>(type: "TEXT", nullable: false),
                    EquipoConsoleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_EquipoConsole_EquipoConsoleId",
                        column: x => x.EquipoConsoleId,
                        principalTable: "EquipoConsole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_EquipoConsoleId",
                table: "Equipo",
                column: "EquipoConsoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "EquipoConsole");
        }
    }
}
