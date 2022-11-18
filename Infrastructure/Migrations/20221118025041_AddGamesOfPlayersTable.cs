using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

public partial class AddGamesOfPlayersTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "GamePlayer",
            columns: table => new
            {
                GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GamePlayer", x => new { x.GamesId, x.PlayersId });
                table.ForeignKey(
                    name: "FK_GamePlayer_Games_GamesId",
                    column: x => x.GamesId,
                    principalTable: "Games",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_GamePlayer_Players_PlayersId",
                    column: x => x.PlayersId,
                    principalTable: "Players",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_GamePlayer_PlayersId",
            table: "GamePlayer",
            column: "PlayersId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "GamePlayer");
    }
}
