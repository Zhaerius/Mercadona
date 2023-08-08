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
        private PromotionEntity? _currentPromotion;
        private double _discountPrice;

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public ICollection<PromotionEntity>? Promotions { get; set; }
        public bool Publish { get; set; }
        public bool OnDiscount { get; set; }

        //Application auto de la promotion la plus avantageuse pour le client
        public PromotionEntity? CurrentPromotion
        {
            get => _currentPromotion;
            private set
            {
                if (this.Promotions is null) 
                    return;

                _currentPromotion = Promotions
                    .Where(p => p.IsActive)
                    .MaxBy(p => p.Discount);

                if (_currentPromotion != null)
                    this.OnDiscount = true;
            }
        }

        //Calcul du prix avec remise
        public double DiscountPrice
        {
            get => _discountPrice;
            private set
            {
                if (this.CurrentPromotion is null) 
                    return;

                _discountPrice = this.BasePrice - (this.BasePrice * this.CurrentPromotion.Discount / 100);
            }
        }
    }
}
