using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public record PromotionDTO(
        Guid Id,
        DateTime Start,
        DateTime End,
        int Discount,
        IEnumerable<ArticleEntity>? Articles
    );
}
