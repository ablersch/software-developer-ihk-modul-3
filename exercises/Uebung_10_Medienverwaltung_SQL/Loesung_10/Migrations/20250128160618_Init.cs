using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medienverwaltung_Aufgabe_9.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medien",
                columns: table => new
                {
                    Signatur = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Seitenzahl = table.Column<int>(type: "int", nullable: true),
                    Laufzeit = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medien", x => x.Signatur);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medien");
        }
    }
}
