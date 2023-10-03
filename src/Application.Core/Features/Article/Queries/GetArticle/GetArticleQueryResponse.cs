using Application.Core.Features.Promotion.Queries.GetPromotion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public class GetArticleQueryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public decimal BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public bool Publish { get; set; }
        public double DiscountPrice { get; set; }
        public ICollection<GetPromotionQueryResponse>? Promotions { get; set; }
        public GetPromotionQueryResponse? CurrentPromotion { get; set; }
    }
}
