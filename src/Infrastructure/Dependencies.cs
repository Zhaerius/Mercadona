using Application.Core.Abstractions;
using Infrastructure.Identity.Options;
using Infrastructure.Identity.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MercaDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("MercaDataBase")));

            services.AddScoped<IApplicationDbContext, MercaDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MercaDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            services.Configure<IdentityUserOptions>(configuration.GetSection("DefaultAdmin"));
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IFileService, FileService>();

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrateur"));
                opts.AddPolicy("RequireUserMercadona", policy => policy.RequireRole("Utilisateur"));
            });

            return services;
        }
    }
}
