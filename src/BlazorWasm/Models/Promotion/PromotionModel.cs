﻿using BlazorWasm.Models.Article;

namespace BlazorWasm.Models.Promotion
{
    public class PromotionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ArticleModel>? Articles { get; set; }
    }
}
