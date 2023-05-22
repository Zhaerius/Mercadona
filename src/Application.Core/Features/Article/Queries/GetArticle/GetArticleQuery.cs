using Application.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public record GetArticleQuery(Guid Id) : IRequest<ArticleResponse>
    {
    }
}
