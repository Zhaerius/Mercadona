﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class ArticleEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public IEnumerable<PromotionEntity>? Promotions { get; set; }
    }
}
