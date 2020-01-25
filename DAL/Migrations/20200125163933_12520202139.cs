using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _12520202139 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerRequest",
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
                    table.PrimaryKey("PK_PlayerRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRequest_User_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerRequest_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRequest_PlayerId",
                table: "PlayerRequest",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRequest_TeamId",
                table: "PlayerRequest",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerRequest");
        }
    }
}
