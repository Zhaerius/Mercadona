using Application.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.UpdateArticle
{
    public record UpdateArticleCommand(
        string? Name,
        string? Description,
        double Price,
        string? Image,
        IEnumerable<CategoryDto>? Categories,
        IEnumerable<PromotionDto>? Promotions) : IRequest;
}
