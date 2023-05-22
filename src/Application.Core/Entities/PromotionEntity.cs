using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class PromotionEntity : BaseEntity
    {
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public required int Discount { get; set; }
        public IEnumerable<ArticleEntity>? Articles { get; set; }

        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set 
            { 
                if (this.End <= DateTime.Now)
                    _IsActive = true; 
            }
        }

    }
}
