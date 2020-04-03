using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _282020424 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchRequest",
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
                    SenderTeamId = table.Column<int>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: false),
                    Contact1 = table.Column<string>(nullable: true),
                    Contact2 = table.Column<string>(nullable: true),
                    ReceiverTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequest_Team_ReceiverTeamId",
                        column: x => x.ReceiverTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchRequest_Team_SenderTeamId",
                        column: x => x.SenderTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequest_ReceiverTeamId",
                table: "MatchRequest",
                column: "ReceiverTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequest_SenderTeamId",
                table: "MatchRequest",
                column: "SenderTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRequest");
        }
    }
}
