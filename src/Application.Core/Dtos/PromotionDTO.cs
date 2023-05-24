using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Dtos
{
    public record PromotionDto
    {
        public Guid Id { get; init; }
        public DateTime Start { get; init; }
        public DateTime End { get; init; }
        public int Discount { get; init; }
        public IEnumerable<ArticleDto>? Articles { get; init; }
    }
}
