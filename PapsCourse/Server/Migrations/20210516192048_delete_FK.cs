using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class delete_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squares_Stores_StoreId",
                table: "Squares");

            migrationBuilder.DropIndex(
                name: "IX_Squares_StoreId",
                table: "Squares");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Squares_StoreId",
                table: "Squares",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Squares_Stores_StoreId",
                table: "Squares",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
