using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScoreTableWithGameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScoreBoardId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameId",
                table: "Scores",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores",
                column: "ScoreBoardId",
                principalTable: "ScoreBoards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Scores");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScoreBoardId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores",
                column: "ScoreBoardId",
                principalTable: "ScoreBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
