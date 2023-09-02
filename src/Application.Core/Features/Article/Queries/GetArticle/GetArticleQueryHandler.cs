using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using Application.Core.Exceptions;

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
            var article = await _dbContext
                .Articles
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            return _mapper.Map<GetArticleQueryResponse>(article);
        }
    }
}
