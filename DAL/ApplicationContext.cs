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
        //private readonly IConfiguration configuration;
        public ApplicationContext():base("Data Source=DESKTOP-BS7R6AC;Initial Catalog=AppDB;Integrated Security=True")
        {

        }
        protected override void InitializeEntities()
        {
            this.InitializeEntity<Role>();
            this.InitializeEntity<RoleRight>();
            this.CreateRelation<Role, RoleRight>(x => x.RoleRights, x => x.Role, x => x.RoleId);
            this.InitializeEntity<User>();
            this.CreateRelation<Role, User>(x => x.Users, x => x.Role, x => x.RoleId);
            this.InitializeEntity<Game>();
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


        }

        //protected override void SeedStaticData(ModelBuilder modelBuilder)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void SeedTestingData(ModelBuilder modelBuilder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
