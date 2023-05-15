using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public class ArticleDto
    {
        public Guid Id { get; init; }
        public string? Name { get; set; }
        public string? Description { get; init; }
        public double Price { get; init; }
        public string? Image { get; init; }
        public IEnumerable<CategoryDto>? Categories { get; init; }
        public IEnumerable<PromotionDto>? Promotions { get; init; }
    }
}
