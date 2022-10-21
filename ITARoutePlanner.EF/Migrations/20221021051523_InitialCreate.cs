using Microsoft.EntityFrameworkCore.Migrations;

namespace ITARoutePlanner.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PositionIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Habitable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Diameter = table.Column<double>(type: "REAL", nullable: false),
                    AverageTemperature = table.Column<int>(type: "INTEGER", nullable: false),
                    DistanceFromEarth = table.Column<double>(type: "REAL", nullable: false),
                    IsDwarf = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spacecrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    GravityGenerator = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxTravelDistance = table.Column<double>(type: "REAL", nullable: false),
                    AsteroidDeflector = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spacecrafts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planetes");

            migrationBuilder.DropTable(
                name: "Spacecrafts");
        }
    }
}
