using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _292020540 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WinningTeamId",
                table: "MatchDetails",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WinningTeamId",
                table: "MatchDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
