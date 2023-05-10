using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public record ArticleDTO(
        Guid Id,
        string Name,
        string Description,
        double Price,
        string Image,
        IEnumerable<CategoryEntity>? Categories,
        IEnumerable<PromotionEntity>? Promotions
        );
}
