using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class ArticleEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public Guid? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public IEnumerable<PromotionEntity>? Promotions { get; set; }
        public required double BasePrice { get; set; }
        public bool OnDiscount { get; set; }


        //Application auto de la promotion la plus avantageuse pour le client
        private PromotionEntity? _currentPromotion;
        public PromotionEntity? CurrentPromotion
        {
            get { return _currentPromotion; }
            private set
            {
                if (this.Promotions is not null)
                {
                    _currentPromotion = Promotions
                        .Where(p => p.IsActive)
                        .OrderByDescending(p => p.Discount)
                        .FirstOrDefault();

                    if (_currentPromotion != null)
                        this.OnDiscount = true;
                }
            }
        }

        //Calcul du prix avec remise
        private double _discountPrice;  
        public double DiscountPrice
        {
            get { return _discountPrice; }
            private set
            {
                if (this.CurrentPromotion is not null)
                    _discountPrice = this.BasePrice - (this.BasePrice * this.CurrentPromotion.Discount / 100);
            }
        }
    }
}
