﻿using BlazorWasm.Models.Promotion;

namespace BlazorWasm.Models.Article
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool Publish { get; set; }
        public decimal DiscountPrice { get; set; }
        public ICollection<PromotionModel>? Promotions { get; set; }
        public PromotionModel? CurrentPromotion { get; set; }

    }
}
