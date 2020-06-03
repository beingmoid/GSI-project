using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Service.Mappings;
using BLL.Service.Services;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.ExceptionHandler;
using Microsoft.Extensions.FileProviders;
using System.IO;
using WebApplication2.Controllers;
using BLL.Service.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Internal;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddAutoMapper(typeof(AutoMapperMappings).Assembly);
            services.AddSignalR();
            services.AddDbContext<EfContext, ApplicationContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();
            

            services.AddAuthentication().AddSteam(options=> {
                options.ApplicationKey = "8F48B0D274523F0FA2252C995B2CBCA1";
                options.CallbackPath = "/Login/Steam";
                options.Authority = new Uri("https://steamcommunity.com/openid/");



            });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
                
            });
            

            #region JWT
            var key = Encoding.ASCII.GetBytes(Configuration["JwtKey"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion


            services.AddSingleton<IFileProvider>(
       new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            services.AddScoped<RequestScope<EfContext>>(provider =>
            {
                var dbContext = provider.GetRequiredService<EfContext>();
                var scope = provider.GetRequiredService<RequestScope>();
                return new RequestScope<EfContext>(scope.ServiceProvider, dbContext, scope.Logger, scope.Mapper, scope.UserId);
            });
            services.AddScoped<RequestScope>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<Program>>();
                var context = provider.GetRequiredService<IHttpContextAccessor>();
                var claims = context.HttpContext.User.Claims;
                var userId = claims.FirstOrDefault(o => o.Type == "UserId")?.Value;

                var mapper = provider.GetRequiredService<IMapper>();

                return new RequestScope(provider, logger, mapper, userId);
            });
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                //if (Environment.IsProduction())
                //{
                //    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                //}
            });
            services.AddSession(options =>
            {
                options.Cookie.Name = "GSI Session";
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.IsEssential = true;

            });
            ConfigureRepositories(services);
            ConfigureAppServices(services);
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IRoleRightRepository, RoleRightRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerRequestRepository, PlayerRequestRepository>();
            services.AddScoped<IPlayerStatsRepository, PlayerStatsRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();
            services.AddScoped<IMatchDetailsRepository, MatchDetailsRepository>();
            services.AddScoped<IMatchRequestRepository, MatchRequestRepository>();
            services.AddScoped<IGameStateRepository, GameStateRepository>();

        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IRoleRightService, RoleRightService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerRequestService, PlayerRequestService>();
            services.AddScoped<IPlayerStatsService, PlayerStatsService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IGameStateService, GameStateService>();
            services.AddScoped<ITeamPlayersService, TeamPlayersService>();
            services.AddScoped<IMatchDetailsService, MatchDetailsService>();
            services.AddScoped<IMatchRequestService, MatchRequestService>();
            services.AddScoped<MatchHub>();
            // services.AddScoped<IHttpContextAccessor,HttpContextAccessor>();



        }
    



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            var hubConfiguration = new HubConfiguration
            {
#if DEBUG
                EnableDetailedErrors = true
#else
            EnableDetailedErrors = false
#endif
            };

           

            
           
            app.UseMiddleware<ExceptionMiddleware>();
           
            app.UseCors("AllowAll");
           
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseSession();
            app.UseMvc();
            
           
    }
}
    }
