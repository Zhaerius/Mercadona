using Application.Core.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotions
{
    public class GetPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, IEnumerable<GetPromotionsQueryResponse>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetPromotionsQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetPromotionsQueryResponse>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
