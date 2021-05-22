using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class Add_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "StatementForRents");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "StatementForRents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_CategoryId",
                table: "StatementForRents",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementForRents_Categories_CategoryId",
                table: "StatementForRents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementForRents_Categories_CategoryId",
                table: "StatementForRents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_StatementForRents_CategoryId",
                table: "StatementForRents");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "StatementForRents");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "StatementForRents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
