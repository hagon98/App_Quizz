using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Quizz.Migrations
{
    public partial class QuizzCreatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quizzCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quizzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizzs_quizzCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "quizzCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizTests_quizzs_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quizTests_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizzQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QstText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    NumOrder = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizzQuestions_quizzs_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizzReponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzReponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizzReponses_quizzQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "quizzQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quizTests_QuizId",
                table: "quizTests",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizTests_UserId",
                table: "quizTests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzQuestions_QuizId",
                table: "quizzQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzReponses_QuestionId",
                table: "quizzReponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzs_CategoryId",
                table: "quizzs",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quizTests");

            migrationBuilder.DropTable(
                name: "quizzReponses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "quizzQuestions");

            migrationBuilder.DropTable(
                name: "quizzs");

            migrationBuilder.DropTable(
                name: "quizzCategories");
        }
    }
}
