using Application.Core.Abstractions;
using Application.Core.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Core.Features.Promotion.Queries.GetPromotionsByStatus
{
    public class GetPromotionsByStatusQueryHandler : IRequestHandler<GetPromotionsByStatusQuery, IEnumerable<GetPromotionsByStatusQueryResponse>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetPromotionsByStatusQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetPromotionsByStatusQueryResponse>> Handle(GetPromotionsByStatusQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PromotionEntity, bool>> filterPredicate;

            if (request.IsActive)
                filterPredicate = p => p.End >= DateOnly.FromDateTime(DateTime.Now);
            else
                filterPredicate = p => p.End < DateOnly.FromDateTime(DateTime.Now);

            var promotions = await dbContext.Promotions
                .Where(filterPredicate)
                .ToListAsync();

            return mapper.Map<IEnumerable<GetPromotionsByStatusQueryResponse>>(promotions);
        }
    }
}
