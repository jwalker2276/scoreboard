using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class ChangeBlackListTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_PlayerNameBlackList",
            table: "PlayerNameBlackList");

        migrationBuilder.RenameTable(
            name: "PlayerNameBlackList",
            newName: "BlackListWords");

        migrationBuilder.AddPrimaryKey(
            name: "PK_BlackListWords",
            table: "BlackListWords",
            column: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_BlackListWords",
            table: "BlackListWords");

        migrationBuilder.RenameTable(
            name: "BlackListWords",
            newName: "PlayerNameBlackList");

        migrationBuilder.AddPrimaryKey(
            name: "PK_PlayerNameBlackList",
            table: "PlayerNameBlackList",
            column: "Id");
    }
}
