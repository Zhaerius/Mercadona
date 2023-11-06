using Application.Core.Features.Article.Queries.GetArticle;
using MediatR;

namespace Application.Core.Features.Article.Queries.GetArticles;

public class GetArticlesQuery : IRequest<IEnumerable<GetArticleQueryResponse>>
{
    public string? Name { get; init; }
    public Guid? CategoryId { get; init; }
}