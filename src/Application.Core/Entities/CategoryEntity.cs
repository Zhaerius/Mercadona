using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public double Name { get; set; }
        public IEnumerable<ArticleEntity>? Articles { get; set; }
    }
}
