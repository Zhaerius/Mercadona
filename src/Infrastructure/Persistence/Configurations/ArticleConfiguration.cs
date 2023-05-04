using Application.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(a => a.Categories)
                .WithMany(c => c.Articles)
                .UsingEntity(x => x.ToTable("ArticleCategory"));

            builder
                .HasMany(a => a.Promotions)
                .WithMany(p => p.Articles)
                .UsingEntity(x => x.ToTable("ArticlePromotion"));

        }
    }
}
