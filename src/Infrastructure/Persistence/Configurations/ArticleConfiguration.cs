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
    public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);


            builder
                .HasMany(a => a.Promotions)
                .WithMany(p => p.Articles)
                .UsingEntity(x => x.ToTable("ArticlePromotion"));

            builder
                .Ignore(a => a.DiscountPrice)
                .Ignore(a => a.CurrentPromotion)
                .Ignore(a => a.OnDiscount);
        }
    }
}
