using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1312020942 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "CaptainId",
                table: "Team",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CaptainId",
                table: "Team",
                newName: "IX_Team_PlayerId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCaptain",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_PlayerId",
                table: "Team",
                column: "PlayerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_PlayerId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "IsCaptain",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Team",
                newName: "CaptainId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_PlayerId",
                table: "Team",
                newName: "IX_Team_CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team",
                column: "CaptainId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
