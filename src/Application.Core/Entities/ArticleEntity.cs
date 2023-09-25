using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class ArticleEntity : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double BasePrice { get; set; }
        public Guid? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public ICollection<PromotionEntity>? Promotions { get; set; }
        public bool Publish { get; set; }
        public bool OnDiscount { get; set; }

        //Application auto de la promotion la plus avantageuse pour le client
        public PromotionEntity? CurrentPromotion
        {
            get 
            {
                if (this.Promotions is null)
                    return null;

                var promotion = Promotions
                    .Where(p => p.IsActive)
                    .MaxBy(p => p.Discount);

                if (promotion != null)
                    this.OnDiscount = true;

                return promotion;
            }
        }

        //Calcul du prix avec remise
        public double DiscountPrice
        {
            get
            {
                if (this.CurrentPromotion is null)
                    return BasePrice;

                return this.BasePrice - (this.BasePrice * this.CurrentPromotion.Discount / 100);
            }
        }
    }
}
