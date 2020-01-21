using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1202019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditUserId = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    GameType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_User_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditUserId = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    TeamImage = table.Column<string>(nullable: true),
                    TeamType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditUserId = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Team1Id = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: false),
                    Contact1 = table.Column<string>(nullable: true),
                    Contact2 = table.Column<string>(nullable: true),
                    Team2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditUserId = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_User_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerId",
                table: "Game",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team1Id",
                table: "Match",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team2Id",
                table: "Match",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_TeamId",
                table: "TeamPlayers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");
        }
    }
}
