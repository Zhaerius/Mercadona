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
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPromotionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetPromotionQueryResponse> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _dbContext.Promotions
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            return _mapper.Map<GetPromotionQueryResponse>(promotions);
        }
    }
}
