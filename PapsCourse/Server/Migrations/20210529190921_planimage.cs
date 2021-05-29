using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class planimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanImage",
                table: "Areas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanImage",
                table: "Areas");
        }
    }
}
