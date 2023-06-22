using Application.Core.Abstractions;
using Infrastructure.Persistence;
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

            return services;
        }
    }
}
