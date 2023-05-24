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
        private PromotionEntity? _CurrentPromotion;
        public PromotionEntity? CurrentPromotion
        {
            get { return _CurrentPromotion; }
            set
            {
                if (this.Promotions is not null)
                {
                    _CurrentPromotion = Promotions
                        .Where(p => p.IsActive)
                        .OrderByDescending(p => p.Discount)
                        .FirstOrDefault();

                    if (_CurrentPromotion != null)
                        this.OnDiscount = true;
                }
            }
        }

        //Calcul du prix avec remise
        private double _DiscountPrice;  
        public double DiscountPrice
        {
            get { return _DiscountPrice; }
            set 
            {
                if (this.CurrentPromotion is not null)
                    _DiscountPrice = this.BasePrice - (this.BasePrice * this.CurrentPromotion.Discount / 100);
            }
        }
    }
}
