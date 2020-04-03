using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _2820204242 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "MatchRequest",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "MatchRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MatchRequest");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "MatchRequest",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
