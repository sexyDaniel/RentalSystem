using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PapsCourse.Server.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerStatements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerStatements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    SquareValue = table.Column<double>(nullable: false),
                    HasContioner = table.Column<bool>(nullable: false),
                    EntriesCount = table.Column<int>(nullable: false),
                    WindowsCount = table.Column<int>(nullable: false),
                    SquarePrice = table.Column<double>(nullable: false),
                    HasToilet = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squares_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementForRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    AverageReciept = table.Column<double>(nullable: false),
                    SquareId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    AnswerStatementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementForRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementForRents_AnswerStatements_AnswerStatementId",
                        column: x => x.AnswerStatementId,
                        principalTable: "AnswerStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatementForRents_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    More = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Squares_SquareId",
                        column: x => x.SquareId,
                        principalTable: "Squares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementForAddedServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(nullable: false),
                    SquareId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    AnswerStatementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementForAddedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementForAddedServices_AnswerStatements_AnswerStatementId",
                        column: x => x.AnswerStatementId,
                        principalTable: "AnswerStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatementForAddedServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatementForAddedServices_Squares_SquareId",
                        column: x => x.SquareId,
                        principalTable: "Squares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_SquareId",
                table: "Histories",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_StoreId",
                table: "Squares",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatementForAddedServices_AnswerStatementId",
                table: "StatementForAddedServices",
                column: "AnswerStatementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatementForAddedServices_ServiceId",
                table: "StatementForAddedServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementForAddedServices_SquareId",
                table: "StatementForAddedServices",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_AnswerStatementId",
                table: "StatementForRents",
                column: "AnswerStatementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatementForRents_StoreId",
                table: "StatementForRents",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "StatementForAddedServices");

            migrationBuilder.DropTable(
                name: "StatementForRents");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "AnswerStatements");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
