﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200201101341_2120201513")]
    partial class _2120201513
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<int>("GameType");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PlayerId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("DAL.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<string>("Contact1");

                    b.Property<string>("Contact2");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal?>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<int?>("Team1Id");

                    b.Property<int?>("Team2Id");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("DAL.Entities.MatchDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MatchId");

                    b.Property<string>("Score");

                    b.Property<bool>("Status");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("WinningTeamId");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("WinningTeamId");

                    b.ToTable("MatchDetails");
                });

            modelBuilder.Entity("DAL.Entities.PlayerRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PlayerId");

                    b.Property<int>("TeamId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerRequest");
                });

            modelBuilder.Entity("DAL.Entities.PlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<int>("Deths");

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Kills");

                    b.Property<int>("MatchId");

                    b.Property<string>("PlayerId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleName");

                    b.Property<int>("RoleType");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DAL.Entities.RoleRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<string>("ControllerId");

                    b.Property<string>("ControllerRightId");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("RoleId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRight");
                });

            modelBuilder.Entity("DAL.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("TeamImage");

                    b.Property<string>("TeamName");

                    b.Property<int>("TeamType");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("DAL.Entities.TeamPlayers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsCaptain");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PlayerId");

                    b.Property<int>("TeamId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("SteamId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("token");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EditTime");

                    b.Property<string>("EditUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PlayerStatsId");

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TenantId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerStatsId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.HasOne("DAL.Entities.User", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.Match", b =>
                {
                    b.HasOne("DAL.Entities.Team", "Team1")
                        .WithMany("Team1")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.Team", "Team2")
                        .WithMany("Team2")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.MatchDetails", b =>
                {
                    b.HasOne("DAL.Entities.Match", "Match")
                        .WithMany("MatchDetails")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.Team", "WinningTeam")
                        .WithMany("WinningTeam")
                        .HasForeignKey("WinningTeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.PlayerRequest", b =>
                {
                    b.HasOne("DAL.Entities.User", "Player")
                        .WithMany("PlayerRequest")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.Team", "Team")
                        .WithMany("PlayerRequest")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Entities.PlayerStats", b =>
                {
                    b.HasOne("DAL.Entities.Match", "Match")
                        .WithMany("PlayerStats")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.User", "Player")
                        .WithMany("PlayerStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.RoleRight", b =>
                {
                    b.HasOne("DAL.Entities.Role", "Role")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.TeamPlayers", b =>
                {
                    b.HasOne("DAL.Entities.User", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.Team", "Team")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.HasOne("DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DAL.Entities.UserProfile", b =>
                {
                    b.HasOne("DAL.Entities.PlayerStats", "PlayerStats")
                        .WithMany("UserProfile")
                        .HasForeignKey("PlayerStatsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.Team", "Team")
                        .WithMany("UserProfile")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UserProfile")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
