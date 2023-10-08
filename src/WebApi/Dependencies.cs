using Application.Core.Abstractions;
using Infrastructure.Identity.Options;
using Infrastructure.Identity.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace WebApi
{
    public static class Dependencies
    {
        public static void InjectDependencies(this WebApplicationBuilder builder)
        {
            builder.AddSwagger();
            builder.AddInfrastructure();

            builder.AddCors();
            builder.AddJwt();
        }

        private static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo { Title = "MercadonaAPI", Version = "v1" });
                opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });
                opts.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }});
            });

            builder.Services.AddEndpointsApiExplorer();
        }

        private static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });
        }
        private static void AddJwt(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(otps =>
                {
                    otps.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    otps.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    otps.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
        private static void AddInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IApplicationDbContext, MercaDbContext>();
            builder.Services.AddDbContext<MercaDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("MercaDataBase")));

            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MercaDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(opts =>
            {
                opts.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrateur"));
                opts.AddPolicy("RequireUserMercadona", policy => policy.RequireRole("Utilisateur"));
            });

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));
            builder.Services.Configure<List<IdentityUserOptions>>(builder.Configuration.GetSection("DefaultAdmin"));

            builder.Services.AddSingleton<IJwtService, JwtService>();
            builder.Services.AddSingleton<IFileService, FileService>();
        }
    }
}
