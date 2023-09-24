using Application.Core.Entities;
using Application.Core.Features.Promotion.Queries.GetPromotion;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticleWithPromotions
{
    public class GetArticleWithPromotionsQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public bool Publish { get; set; }
        public double DiscountPrice { get; set; }
        public ICollection<GetPromotionQueryResponse>? Promotions { get; set; }
        public GetPromotionQueryResponse? CurrentPromotion { get; set; }
    }
}
