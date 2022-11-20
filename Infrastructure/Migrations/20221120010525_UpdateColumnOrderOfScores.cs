using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

public partial class UpdateColumnOrderOfScores : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            name: "Value",
            table: "Scores",
            type: "int",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int")
            .Annotation("Relational:ColumnOrder", 1);

        migrationBuilder.AlterColumn<Guid>(
            name: "PlayerId",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .Annotation("Relational:ColumnOrder", 3);

        migrationBuilder.AlterColumn<Guid>(
            name: "GameId",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .Annotation("Relational:ColumnOrder", 2);

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "CreationDate",
            table: "Scores",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset")
            .Annotation("Relational:ColumnOrder", 4);

        migrationBuilder.AlterColumn<string>(
            name: "CreatedBy",
            table: "Scores",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(256)",
            oldMaxLength: 256)
            .Annotation("Relational:ColumnOrder", 5);

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .Annotation("Relational:ColumnOrder", 0);

        migrationBuilder.AddColumn<Guid>(
            name: "ScoreBoardId",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Scores_GameId",
            table: "Scores",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_Scores_ScoreBoardId",
            table: "Scores",
            column: "ScoreBoardId");

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

        migrationBuilder.DropIndex(
            name: "IX_Scores_ScoreBoardId",
            table: "Scores");

        migrationBuilder.DropColumn(
            name: "ScoreBoardId",
            table: "Scores");

        migrationBuilder.AlterColumn<int>(
            name: "Value",
            table: "Scores",
            type: "int",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int")
            .OldAnnotation("Relational:ColumnOrder", 1);

        migrationBuilder.AlterColumn<Guid>(
            name: "PlayerId",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .OldAnnotation("Relational:ColumnOrder", 3);

        migrationBuilder.AlterColumn<Guid>(
            name: "GameId",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .OldAnnotation("Relational:ColumnOrder", 2);

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "CreationDate",
            table: "Scores",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset")
            .OldAnnotation("Relational:ColumnOrder", 4);

        migrationBuilder.AlterColumn<string>(
            name: "CreatedBy",
            table: "Scores",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(256)",
            oldMaxLength: 256)
            .OldAnnotation("Relational:ColumnOrder", 5);

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Scores",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier")
            .OldAnnotation("Relational:ColumnOrder", 0);
    }
}
