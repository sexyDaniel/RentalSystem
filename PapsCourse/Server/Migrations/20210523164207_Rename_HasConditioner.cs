using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class Rename_HasConditioner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasContioner",
                table: "Areas");

            migrationBuilder.AddColumn<bool>(
                name: "HasConditioner",
                table: "Areas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasConditioner",
                table: "Areas");

            migrationBuilder.AddColumn<bool>(
                name: "HasContioner",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
