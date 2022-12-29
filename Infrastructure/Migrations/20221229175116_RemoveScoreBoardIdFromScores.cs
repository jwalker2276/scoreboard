using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveScoreBoardIdFromScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ScoreBoardId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ScoreBoardId",
                table: "Scores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScoreBoardId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ScoreBoardId",
                table: "Scores",
                column: "ScoreBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoreBoards_ScoreBoardId",
                table: "Scores",
                column: "ScoreBoardId",
                principalTable: "ScoreBoards",
                principalColumn: "Id");
        }
    }
}
