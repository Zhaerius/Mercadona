using Application.Core.Abstractions;
using Application.Core.Entities;
using Application.Core.Common.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Core.Features.Promotion.Queries.GetPromotion
{
    public class GetPromotionQueryHandler : IRequestHandler<GetPromotionQuery, GetPromotionQueryResponse>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetPromotionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<GetPromotionQueryResponse> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            var promotions = await dbContext.Promotions
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            return mapper.Map<GetPromotionQueryResponse>(promotions);
        }
    }
}
