using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationContext : EfContext
    {
    
        private readonly IConfiguration _configuration;
        public ApplicationContext(IConfiguration configuration):base(configuration["DefaultConnection"])
        {

        }
        protected override void InitializeEntities()
        {
            this.InitializeEntity<Role>();
            this.InitializeEntity<RoleRight>();
            this.CreateRelation<Role, RoleRight>(x => x.RoleRights, x => x.Role, x => x.RoleId);
            this.InitializeEntity<User>();
            this.InitializeEntity<Game>();
            this.CreateRelation<Role, User>(x => x.Users, x => x.Role, x => x.RoleId);
            this.CreateRelation<User, Game>(x => x.Games, x => x.Player, x => x.PlayerId);
            this.InitializeEntity<Team>();
            this.InitializeEntity<TeamPlayers>();
            this.CreateRelation<Team, TeamPlayers>(x => x.TeamPlayers, x => x.Team, x => x.TeamId);
             this.CreateRelation<User, TeamPlayers>(x => x.TeamPlayers, x => x.Player, x => x.PlayerId);
            this.InitializeEntity<Match>();
            this.CreateRelation<Team, Match>(x => x.Team1, x => x.Team1, x => x.Team1Id);
            this.CreateRelation<Team, Match>(x => x.Team2, x => x.Team2, x => x.Team2Id);
            this.InitializeEntity<MatchDetails>();
            this.CreateRelation<Team, MatchDetails>(x => x.WinningTeam, x => x.WinningTeam, x => x.WinningTeamId);
            this.CreateRelation<Match, MatchDetails>(x => x.MatchDetails, x => x.Match, x => x.MatchId);
            this.InitializeEntity<PlayerRequest>();
            this.CreateRelation<User, PlayerRequest>(x => x.PlayerRequest, x => x.Player, x => x.PlayerId);

            this.InitializeEntity<PlayerStats>();
            this.CreateRelation<User, PlayerStats>(x => x.PlayerStats, x => x.Player, x => x.PlayerId);
            this.CreateRelation<Match, PlayerStats>(x => x.PlayerStats, x => x.Match, x => x.MatchId);

            this.InitializeEntity<UserProfile>();
            this.CreateRelation<User, UserProfile>(x => x.UserProfile, x => x.User, x => x.UserId);
            this.CreateRelation<Team, UserProfile>(x => x.UserProfile, x => x.Team, x => x.TeamId);
            this.CreateRelation<PlayerStats, UserProfile>(x => x.UserProfile, x => x.PlayerStats, x => x.PlayerStatsId);

            this.InitializeEntity<MatchRequest>();
            this.CreateRelation<Team, MatchRequest>(x => x.SenderMatchRequest, x => x.SenderTeam, x => x.SenderTeamId);
            this.CreateRelation<Team, MatchRequest>(x => x.ReceiverMatchRequest, x => x.ReceiverTeam, x => x.ReceiverTeamId);
            this.InitializeEntity<GameStates>();
            this.CreateRelation<Match, GameStates>(x => x.GameStates, x => x.Match, x => x.MatchId);
            //  this.CreateRelation<User, Team>(x => x.Teams, x => x.Player, x => x.PlayerId);

        }

        protected override void SeedStaticData(ModelBuilder modelBuilder)
        {
            #region Roles
            this.SeedData(
                new Role { Id = 1, RoleName= "Admin", RoleType = RoleType.Admin },
            new Role { Id = 2, RoleName = "Player", RoleType = RoleType.Player });

            #endregion

            #region Users
            this.SeedData(
                new User { Id = "xnxAdmin", Password = "xnxAdmin", RoleId = 1 },
            new User { Id = "xnxPlayer", Password = "xnxPlayer", RoleId = 2 });

            #endregion
        }

        //protected override void SeedTestingData(ModelBuilder modelBuilder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
