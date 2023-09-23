using Application.Core.Entities;
using BlazorServer.BackOffice.Models.Promotion;

namespace BlazorServer.BackOffice.Models.Article
{
    public class HandlerArticlePromotionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }
        public ICollection<PromotionModel>? Promotions { get; set; }
        public PromotionModel? CurrentPromotion { get; set; }
    }
}
