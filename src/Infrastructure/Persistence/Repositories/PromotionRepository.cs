using Application.Core.Entities;
using Application.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PromotionRepository : Repository<PromotionEntity>, IPromotionRepository
    {
        public PromotionRepository(MercaDbContext mercaDbContext) : base(mercaDbContext)
        {
        }
    }
}
