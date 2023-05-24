using Application.Core.Abstractions;
using Application.Core.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.SearchArticles
{
    public class SearchArticlesQueryHandler : IRequestHandler<SearchArticlesQuery, IEnumerable<SearchArticlesQueryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchArticlesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchArticlesQueryResponse>> Handle(SearchArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _dbContext.Articles
                .Include(a => a.Category)
                .Where(a => a.Name.ToLower().Contains(request.Name.ToLower()))
                .ToListAsync();

            if (articles.Count() == 0)
                throw new NotFoundException();

            var mapping = _mapper.Map<IEnumerable<SearchArticlesQueryResponse>>(articles);

            return mapping;
        }
    }
}
