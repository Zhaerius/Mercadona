using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using Application.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.GetArticleWithPromotions
{
    public class GetArticleWithPromotionsQueryHandler : IRequestHandler<GetArticleWithPromotionsQuery, GetArticleWithPromotionsQueryResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleWithPromotionsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetArticleWithPromotionsQueryResponse> Handle(GetArticleWithPromotionsQuery request, CancellationToken cancellationToken)
        {
            var article = await _dbContext.Articles
                .Include(a => a.Promotions)
                .FirstAsync(a => a.Id == request.Id, cancellationToken) ?? throw new NotFoundException();

            return _mapper.Map<GetArticleWithPromotionsQueryResponse>(article);
        }
    }
}
