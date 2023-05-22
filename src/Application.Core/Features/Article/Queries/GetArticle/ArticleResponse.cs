using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public record ArticleResponse(
        Guid Id,
        string? Name,
        string? Description,
        double Price,
        string? Image,
        Guid CategoryId,
        string CategoryName){}
}
