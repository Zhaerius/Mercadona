using Application.Core.Abstractions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MercaDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("MercaDataBase")));

            services.AddScoped<IApplicationDbContext, MercaDbContext>();

            return services;
        }
    }
}
