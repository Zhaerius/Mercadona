using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public record ArticleDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required double Price { get; init; }
        public required string Image { get; init; }
        public required bool OnDiscount { get; init; }
        public required double PriceDiscount { get; init; }
        public CategoryDto? Category { get; init; }
        public IEnumerable<PromotionDto>? Promotions { get; init; }
    }
}
