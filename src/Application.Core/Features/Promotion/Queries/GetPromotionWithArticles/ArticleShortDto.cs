using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Queries.GetPromotionWithArticles
{
    public class ArticleShortDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string? CategoryName { get; set; }
        public bool Publish { get; set; }
    }
}
