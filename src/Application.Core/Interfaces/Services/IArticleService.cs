using Application.Core.Dtos;
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
        public ArticleDTO GetArticle(Guid id);
        public IEnumerable<ArticleDTO> GetArticles();
        public void AddArticle(ArticleDTO article);
    }
}
