using Application.Core.Features.Article.Queries.GetArticles;

namespace Application.Core.Features.Promotion.Queries.GetPromotionWithArticles
{
    public class GetPromotionArticlesQueryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateOnly Start { get; set; }
        public  DateOnly End { get; set; }
        public  int Discount { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ArticleShortDto>? Articles { get; set; }
    }
}
