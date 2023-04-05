using MatchScore.Data.Data;
using MatchScore.Data.Repositories;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Services.Services;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace MatchScore.Web
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
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "JWT_OR_COOKIE";
                options.DefaultChallengeScheme = "JWT_OR_COOKIE";
            })
            .AddCookie(/*"Cookie", */options =>
            {
                options.LoginPath = "/users/login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly= true;
                options.Cookie.IsEssential = true;
            })
            .AddJwtBearer(/*"Bearer", */options =>
            {
                //options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtToken:Audience"],
                    //ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
                };
            })
            .AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    string authorization = context.Request.Headers[/*HeaderNames.Authorization*/"Authorization"];

                    if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                    {
                        //return "Bearer";
                        return JwtBearerDefaults.AuthenticationScheme;
                    }
                    else
                    {
                        //return "Cookies";
                        return CookieAuthenticationDefaults.AuthenticationScheme;
                    }
                };
            });

            services.AddAuthorization();

            // View Controllers
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            //Register IHttpClientFactory
            services.AddHttpClient();

            // Repositories
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<ISportsClubsRepository, SportsClubsRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IAwardsRepository, AwardsRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRankingsRepository, RankingsRepository>();
            services.AddScoped<IRequestsRepository, RequestsRepository>();

            // Services
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IAwardsService, AwardsService>();
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IPlayersService, PlayersService>();
            services.AddScoped<IMatchesService, MatchesService>();
            services.AddScoped<ILocationsService, LocationsService>();
            services.AddScoped<ISportsClubsService, SportsClubsService>();
            services.AddScoped<IRankingsService, RankingsService>();
            services.AddScoped<IRequestsService, RequestsService>();

            // Helpers
            services.AddScoped<AuthHelper>();
            services.AddScoped<EmailHelper>();

            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Match Score API",
                    Description = "Match Score API Swagger documentation",
                    Version = "v1"
                });

                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },

                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Match Score API V1");
                options.RoutePrefix = "api/swagger";
            });
        }
    }
}
