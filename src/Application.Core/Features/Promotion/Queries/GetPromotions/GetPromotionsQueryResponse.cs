using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotions
{
    public record GetPromotionsQueryResponse(
        string Name,
        DateOnly Start,
        DateOnly End,
        int Discount)
    {
    }
}
