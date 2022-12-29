using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveScoreBoardIdFromGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_GameId",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "ScoreBoardId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_GameId",
                table: "ScoreBoards",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_GameId",
                table: "ScoreBoards");

            migrationBuilder.AddColumn<Guid>(
                name: "ScoreBoardId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_GameId",
                table: "ScoreBoards",
                column: "GameId",
                unique: true);
        }
    }
}
