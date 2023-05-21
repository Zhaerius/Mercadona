using Application.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<ArticleEntity> Articles { get; set; }
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<PromotionEntity> Promotion { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
