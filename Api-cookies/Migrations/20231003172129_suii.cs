using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_cookies.Migrations
{
    /// <inheritdoc />
    public partial class suii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "CookiesStand",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "SalesHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    cookiestandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesHour_CookiesStand_cookiestandId",
                        column: x => x.cookiestandId,
                        principalTable: "CookiesStand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesHour_cookiestandId",
                table: "SalesHour",
                column: "cookiestandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesHour");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CookiesStand",
                newName: "id");
        }
    }
}
