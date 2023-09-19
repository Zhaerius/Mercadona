using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotion
{
    public record GetPromotionQueryResponse(
        Guid Id,
        string Name,
        DateOnly Start,
        DateOnly End,
        int Discount) {}
}
