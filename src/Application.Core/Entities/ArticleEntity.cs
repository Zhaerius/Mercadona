namespace Application.Core.Entities
{
    public class ArticleEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public decimal BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public ICollection<PromotionEntity>? Promotions { get; set; }
        public bool Publish { get; set; }


        //Application auto de la promotion la plus avantageuse pour le client
        public PromotionEntity? CurrentPromotion
        {
            get  
            {
                if (Promotions is null)
                    return null;

                return Promotions
                    .Where(p => p.IsActive)
                    .MaxBy(p => p.Discount);
            }
        }

        //Determination auto du statut de l'article
        public bool OnDiscount => CurrentPromotion is not null;

        //Calcul du prix avec remise
        public decimal DiscountPrice
        {
            get
            {
                if (CurrentPromotion is null)
                    return BasePrice;

                return BasePrice - (BasePrice * CurrentPromotion.Discount / 100);
            }
        }
    }
}
