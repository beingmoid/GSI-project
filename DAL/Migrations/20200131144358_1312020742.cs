using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1312020742 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaptainId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_CaptainId",
                table: "Team",
                column: "CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team",
                column: "CaptainId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_CaptainId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CaptainId",
                table: "Team");
        }
    }
}
