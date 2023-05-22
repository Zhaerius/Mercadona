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
        public required double Price { get; set; }
        public required string Image { get; set; }
        public Guid? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public IEnumerable<PromotionEntity>? Promotions { get; set; }

        public bool OnDiscount { get; set; }

        //Application auto de la promotion la plus avantageuse pour le client
        private double _PriceDiscount;  
        public double PriceDiscount
        {
            get { return _PriceDiscount; }
            set 
            {
                _PriceDiscount = this.Price;

                if (Promotions is not null)
                {
                    var promotionToAplly = Promotions
                        .Where(p => p.IsActive)
                        .OrderByDescending(p => p.Discount)
                        .FirstOrDefault();

                    if (promotionToAplly is not null)
                    {
                        this.OnDiscount = true;
                        _PriceDiscount = this.Price - (this.Price * promotionToAplly.Discount / 100);
                    }
                }
            }
        }
    }
}
