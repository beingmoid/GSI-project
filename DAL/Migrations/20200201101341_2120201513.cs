using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _2120201513 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_PlayerId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_PlayerId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "IsCaptain",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Team");

            migrationBuilder.AddColumn<bool>(
                name: "IsCaptain",
                table: "TeamPlayers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCaptain",
                table: "TeamPlayers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCaptain",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayerId",
                table: "Team",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_PlayerId",
                table: "Team",
                column: "PlayerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
