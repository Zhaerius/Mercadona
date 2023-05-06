using Application.Core.Entities;
using Application.Core.Interfaces.Repositories;
using Application.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public ArticleEntity GetArticle(Guid id)
        {
            return _articleRepository.GetById(id);
        }

        public IEnumerable<ArticleEntity> GetArticles()
        {
            return _articleRepository.GetAll();
        }

        public void AddArticle(ArticleEntity article)
        {
            _articleRepository.Create(article);
        }
    }
}
