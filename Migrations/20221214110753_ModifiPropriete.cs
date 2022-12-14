using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Quizz.Migrations
{
    public partial class ModifiPropriete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzQuestions_quizzs_QuizId",
                table: "quizzQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_quizzReponses_quizzQuestions_QuestionId",
                table: "quizzReponses");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "quizzReponses",
                newName: "QuizzQuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzReponses_QuestionId",
                table: "quizzReponses",
                newName: "IX_quizzReponses_QuizzQuestionsId");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "quizzQuestions",
                newName: "QuizzId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzQuestions_QuizId",
                table: "quizzQuestions",
                newName: "IX_quizzQuestions_QuizzId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "quizzCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzQuestions_quizzs_QuizzId",
                table: "quizzQuestions",
                column: "QuizzId",
                principalTable: "quizzs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quizzReponses_quizzQuestions_QuizzQuestionsId",
                table: "quizzReponses",
                column: "QuizzQuestionsId",
                principalTable: "quizzQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzQuestions_quizzs_QuizzId",
                table: "quizzQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_quizzReponses_quizzQuestions_QuizzQuestionsId",
                table: "quizzReponses");

            migrationBuilder.RenameColumn(
                name: "QuizzQuestionsId",
                table: "quizzReponses",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzReponses_QuizzQuestionsId",
                table: "quizzReponses",
                newName: "IX_quizzReponses_QuestionId");

            migrationBuilder.RenameColumn(
                name: "QuizzId",
                table: "quizzQuestions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzQuestions_QuizzId",
                table: "quizzQuestions",
                newName: "IX_quizzQuestions_QuizId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "quizzCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quizzQuestions_quizzs_QuizId",
                table: "quizzQuestions",
                column: "QuizId",
                principalTable: "quizzs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quizzReponses_quizzQuestions_QuestionId",
                table: "quizzReponses",
                column: "QuestionId",
                principalTable: "quizzQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
