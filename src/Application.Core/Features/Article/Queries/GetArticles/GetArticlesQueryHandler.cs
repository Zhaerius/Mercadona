using Application.Core.Abstractions;
using Application.Core.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.GetArticles;

public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<GetArticlesQueryResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetArticlesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetArticlesQueryResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ArticleEntity> articles = _dbContext.Articles;

        if (!string.IsNullOrEmpty(request.Name))
            articles = articles.Where(a => a.Name.ToLower().Contains(request.Name.ToLower()));
        if (request.CategoryId is not null)
            articles = articles.Where(a => a.CategoryId == request.CategoryId);
        if (request.Publish is not null)
            articles = articles.Where(a => a.Publish == request.Publish);

        var entities = await articles
            .Include(a => a.Promotions)
            .ToListAsync(cancellationToken);

        if (request.OnDiscount is not null)
        {
            entities = entities
                .Where(a => a.OnDiscount == request.OnDiscount)
                .ToList();
        }
        
        return _mapper.Map<IEnumerable<GetArticlesQueryResponse>>(entities);

    }
}