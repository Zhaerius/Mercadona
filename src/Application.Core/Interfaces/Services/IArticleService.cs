using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces.Services
{
    public interface IArticleService
    {
        public ArticleEntity GetArticle(Guid id);
        public IEnumerable<ArticleEntity> GetArticles();
        public void AddArticle(ArticleEntity article);
    }
}
