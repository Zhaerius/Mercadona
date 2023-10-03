using MediatR;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public record CreateArticleCommand(
        string Name,
        string Description,
        string Image,
        decimal BasePrice,
        Guid CategoryId,
        IEnumerable<Guid>? PromotionsIds,
        bool Publish) : IRequest<Guid> {}
}
