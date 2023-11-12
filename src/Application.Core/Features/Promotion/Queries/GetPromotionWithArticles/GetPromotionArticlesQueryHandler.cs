using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotionWithArticles
{
    public class GetPromotionArticlesQueryHandler : IRequestHandler<GetPromotionArticlesQuery, GetPromotionArticlesQueryResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPromotionArticlesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetPromotionArticlesQueryResponse> Handle(GetPromotionArticlesQuery request, CancellationToken cancellationToken)
        {
            #nullable disable
            var promotion = await _dbContext.Promotions
                .Where(p => p.Id == request.Id)
                .Include(p => p.Articles)
                .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync() ?? throw new NotFoundException();
            #nullable restore

            return _mapper.Map<GetPromotionArticlesQueryResponse>(promotion);
        }
    }
}
