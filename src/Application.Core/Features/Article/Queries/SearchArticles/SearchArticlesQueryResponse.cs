using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.SearchArticles
{
    public class SearchArticlesQueryResponse
    {
        public SearchArticlesQueryResponse(Guid id, string? name, string? categoryName, double basePrice)
        {
            Id = id;
            Name = name;
            CategoryName = categoryName;
            BasePrice = basePrice;
        }

        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? CategoryName { get; init; }
        public double BasePrice { get; init; }
    }
}
