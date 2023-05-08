using Application.Core.Interfaces.Services;
using Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
