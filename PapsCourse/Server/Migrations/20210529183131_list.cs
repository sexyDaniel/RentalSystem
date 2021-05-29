using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StatementForRents_StoreId",
                table: "StatementForRents");

            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_StoreId",
                table: "StatementForRents",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StatementForRents_StoreId",
                table: "StatementForRents");

            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_StoreId",
                table: "StatementForRents",
                column: "StoreId",
                unique: true);
        }
    }
}
