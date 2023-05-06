using Application.Core.Entities;
using Application.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : Repository<ArticleEntity>, IArticleRepository
    {
        public ArticleRepository(MercaDbContext mercaDbContext) : base(mercaDbContext)
        {           
        }
    }
}
