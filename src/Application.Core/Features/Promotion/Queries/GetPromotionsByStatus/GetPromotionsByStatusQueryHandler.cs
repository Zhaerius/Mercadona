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
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPromotionsByStatusQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GetPromotionsByStatusQueryResponse>> Handle(GetPromotionsByStatusQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PromotionEntity, bool>> filterPredicate;

            if (request.IsActive)
                filterPredicate = p => p.End >= DateOnly.FromDateTime(DateTime.Now);
            else
                filterPredicate = p => p.End < DateOnly.FromDateTime(DateTime.Now);

            var promotions = await _dbContext.Promotions
                .Where(filterPredicate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GetPromotionsByStatusQueryResponse>>(promotions);
        }
    }
}
