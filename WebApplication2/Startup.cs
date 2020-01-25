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
            services.AddAutoMapper(typeof(AutoMapperMappings).Assembly);
            services.AddDbContext<EfContext, ApplicationContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

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
            services.AddAuthentication().AddSteam();
            #endregion


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
                var userId = claims.FirstOrDefault(o => o.Type == "user_id")?.Value;

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
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseMvc();
    }
}
    }
