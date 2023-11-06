using MediatR;

namespace Application.Core.Features.Article.Queries.GetArticles;

public class GetArticlesQuery : IRequest<IEnumerable<GetArticlesQueryResponse>>
{
    public string? Name { get; init; }
    public Guid? CategoryId { get; init; }
    public bool? Publish { get; init; }
    public bool? OnDiscount { get; init; }
}