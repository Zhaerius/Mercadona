using Application.Core.Entities;
using Application.Core.Features.Promotion.Queries.GetPromotion;
using MediatR;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Publish { get; set; }
        public double DiscountPrice { get; set; }
        public GetPromotionQueryResponse? CurrentPromotion { get; set; }
    }
}
