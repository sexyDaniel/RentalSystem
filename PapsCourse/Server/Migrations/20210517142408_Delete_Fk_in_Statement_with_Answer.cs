using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class Delete_Fk_in_Statement_with_Answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementForAddedServices_AnswerStatements_AnswerStatementId",
                table: "StatementForAddedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_StatementForRents_AnswerStatements_AnswerStatementId",
                table: "StatementForRents");

            migrationBuilder.DropIndex(
                name: "IX_StatementForRents_AnswerStatementId",
                table: "StatementForRents");

            migrationBuilder.DropIndex(
                name: "IX_StatementForAddedServices_AnswerStatementId",
                table: "StatementForAddedServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_AnswerStatementId",
                table: "StatementForRents",
                column: "AnswerStatementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatementForAddedServices_AnswerStatementId",
                table: "StatementForAddedServices",
                column: "AnswerStatementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StatementForAddedServices_AnswerStatements_AnswerStatementId",
                table: "StatementForAddedServices",
                column: "AnswerStatementId",
                principalTable: "AnswerStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatementForRents_AnswerStatements_AnswerStatementId",
                table: "StatementForRents",
                column: "AnswerStatementId",
                principalTable: "AnswerStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
