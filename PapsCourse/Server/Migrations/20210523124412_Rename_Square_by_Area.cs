using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class Rename_Square_by_Area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Squares_SquareId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_StatementForAddedServices_Squares_SquareId",
                table: "StatementForAddedServices");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    Square = table.Column<double>(nullable: false),
                    HasContioner = table.Column<bool>(nullable: false),
                    EntriesCount = table.Column<int>(nullable: false),
                    WindowsCount = table.Column<int>(nullable: false),
                    SquarePrice = table.Column<double>(nullable: false),
                    HasToilet = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Areas_SquareId",
                table: "Histories",
                column: "SquareId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatementForAddedServices_Areas_SquareId",
                table: "StatementForAddedServices",
                column: "SquareId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Areas_SquareId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_StatementForAddedServices_Areas_SquareId",
                table: "StatementForAddedServices");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntriesCount = table.Column<int>(type: "int", nullable: false),
                    HasContioner = table.Column<bool>(type: "bit", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    SquarePrice = table.Column<double>(type: "float", nullable: false),
                    SquareValue = table.Column<double>(type: "float", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    WindowsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Squares_SquareId",
                table: "Histories",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatementForAddedServices_Squares_SquareId",
                table: "StatementForAddedServices",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
