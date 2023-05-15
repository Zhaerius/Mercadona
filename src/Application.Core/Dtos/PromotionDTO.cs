﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public record PromotionDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Discount { get; set; }
        public IEnumerable<ArticleDto>? Articles { get; set; }
    }
}