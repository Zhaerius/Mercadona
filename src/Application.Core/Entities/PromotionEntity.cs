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
        public required DateOnly Start { get; set; }
        public required DateOnly End { get; set; }
        public required int Discount { get; set; }
        public IEnumerable<ArticleEntity>? Articles { get; set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            private set 
            { 
                if (this.End <= DateOnly.FromDateTime(DateTime.Now))
                    _isActive = true; 
            }
        }

    }
}
