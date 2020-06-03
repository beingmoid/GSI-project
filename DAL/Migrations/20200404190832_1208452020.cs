using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1208452020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "MatchRequest",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MatchTimings",
                table: "MatchRequest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MatchType",
                table: "MatchRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchTimings",
                table: "MatchRequest");

            migrationBuilder.DropColumn(
                name: "MatchType",
                table: "MatchRequest");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "MatchRequest",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
