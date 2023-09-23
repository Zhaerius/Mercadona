using MediatR;

namespace Application.Core.Features.Article.Queries.GetArticleWithPromotions
{
    public record GetArticleWithPromotionsQuery(Guid Id) : IRequest<GetArticleWithPromotionsQueryResponse>
    {
    }
}
