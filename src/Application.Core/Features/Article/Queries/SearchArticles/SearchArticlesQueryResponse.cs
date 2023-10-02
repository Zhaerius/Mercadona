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
        public string Name { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
        public decimal BasePrice { get; init; }
    }
}
