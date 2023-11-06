using Application.Core.Abstractions;
using Application.Core.Entities;
using Application.Core.Features.Article.Queries.GetArticle;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.GetArticles;

public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<GetArticleQueryResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetArticlesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetArticleQueryResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ArticleEntity> articles = _dbContext.Articles;

        if (!string.IsNullOrEmpty(request.Name))
        {
            articles = articles.Where(a => a.Name.Contains(request.Name));
        }
        else if (request.CategoryId is not null)
        {
            articles = articles.Where(a => a.CategoryId == request.CategoryId);
        }
        
        return _mapper.Map<IEnumerable<GetArticleQueryResponse>>(await articles.ToListAsync(cancellationToken));

    }
}