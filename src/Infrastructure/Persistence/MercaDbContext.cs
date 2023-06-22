using Application.Core.Entities;
using Application.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MercaDbContext : IdentityDbContext, IApplicationDbContext
    {
        public MercaDbContext(DbContextOptions<MercaDbContext> options) : base(options)
        {
        }

        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PromotionEntity> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
