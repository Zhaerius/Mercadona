using Application.Core.Interfaces.Services;
using Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Core
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
