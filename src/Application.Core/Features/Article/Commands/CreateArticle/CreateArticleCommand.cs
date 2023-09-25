using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public record CreateArticleCommand(
        string Name,
        string Description,
        string Image,
        double BasePrice,
        Guid CategoryId,
        IEnumerable<Guid>? PromotionsIds,
        bool Publish) : IRequest<Guid>{ }
}
