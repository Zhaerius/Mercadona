using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using Application.Core.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, GetArticleQueryResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetArticleQueryResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _dbContext.Articles
                .Include(a => a.Category)
                .Include(a => a.Promotions)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken) ?? throw new NotFoundException();

            return _mapper.Map<GetArticleQueryResponse>(article);
        }
    }
}
