using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class PromotionEntity : BaseEntity
    {
        public required string Name { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int Discount { get; set; }
        public IEnumerable<ArticleEntity>? Articles { get; set; }

        public bool IsActive => this.End >= DateOnly.FromDateTime(DateTime.Now);
    }
}
