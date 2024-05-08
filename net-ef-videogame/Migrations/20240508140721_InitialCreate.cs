using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwareHouses",
                columns: table => new
                {
                    SoftwareHouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouses", x => x.SoftwareHouseId);
                });

            migrationBuilder.CreateTable(
                name: "videogame",
                columns: table => new
                {
                    VideogmaeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftwarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogame", x => x.VideogmaeId);
                    table.ForeignKey(
                        name: "FK_videogame_SoftwareHouses_SoftwarehouseId",
                        column: x => x.SoftwarehouseId,
                        principalTable: "SoftwareHouses",
                        principalColumn: "SoftwareHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_videogame_Name",
                table: "videogame",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwarehouseId",
                table: "videogame",
                column: "SoftwarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogame");

            migrationBuilder.DropTable(
                name: "SoftwareHouses");
        }
    }
}
