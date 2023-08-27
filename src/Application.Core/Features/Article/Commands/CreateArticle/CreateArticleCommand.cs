using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    //public record CreateArticleCommand(
    //    string Name,
    //    string Description,
    //    double BasePrice,
    //    IBrowserFile Image,
    //    Guid CategoryId,
    //    IEnumerable<Guid>? PromotionsIds,
    //    bool Publish) : IRequest{}

    public class CreateArticleCommand : IRequest
    {
        //public string? Name { get; set; }
        //public string? Description { get; set; }
        //public Guid? CategoryId { get; set; }
        public IBrowserFile? Image { get; set; }
        //public double BasePrice { get; set; }
        //public bool Publish { get; set; }
    }
}
