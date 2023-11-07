using Application.Core.Features.Promotion.Queries.GetPromotion;

namespace Application.Core.Features.Article.Queries.GetArticles;

public class GetArticlesQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public decimal BasePrice { get; set; }
    public Guid CategoryId { get; set; }
    public bool Publish { get; set; }
    public bool OnDiscount { get; set; }
    public double DiscountPrice { get; set; }
    public GetPromotionQueryResponse? CurrentPromotion { get; set; }
}