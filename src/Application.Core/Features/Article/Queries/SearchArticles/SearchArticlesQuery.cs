using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.SearchArticles
{
    public record SearchArticlesQuery(string Name) : IRequest<IEnumerable<SearchArticlesQueryResponse>>
    {
    }
}
