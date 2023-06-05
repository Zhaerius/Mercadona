﻿using System;
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
        public required Guid CategoryId { get; set; }
        public required CategoryEntity Category { get; set; }
        public IEnumerable<PromotionEntity>? Promotions { get; set; }
        public bool OnDiscount { get; set; }


        //Application auto de la promotion la plus avantageuse pour le client
        private PromotionEntity? _currentPromotion;
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
        private double _discountPrice;  
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
