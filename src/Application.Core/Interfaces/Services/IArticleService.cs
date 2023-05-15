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
        public ArticleDto GetArticle(Guid id);
        public IEnumerable<ArticleDto> GetArticles();
        public void AddArticle(ArticleDto article);
    }
}
