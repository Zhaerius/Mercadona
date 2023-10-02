using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.SearchArticles
{
    public class SearchArticlesQueryResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string CategoryName { get; init; }
        public decimal BasePrice { get; init; }
    }
}
