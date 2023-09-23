using Application.Core.Entities;
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
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }
        public ICollection<PromotionEntity>? Promotions { get; set; }
        public PromotionEntity? CurrentPromotion { get; set; }
    }
}
