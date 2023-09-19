using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotionsByStatus
{
    public record GetPromotionsByStatusQuery(bool IsActive) : IRequest<IEnumerable<GetPromotionsByStatusQueryResponse>>
    {
    }
}
