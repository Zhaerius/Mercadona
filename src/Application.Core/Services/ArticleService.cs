using Application.Core.Dtos;
using Application.Core.Entities;
using Application.Core.Interfaces.Repositories;
using Application.Core.Interfaces.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }


        public ArticleDTO GetArticle(Guid id)
        {
            var article = _articleRepository.GetById(id);
            return _mapper.Map<ArticleDTO>(article);
        }

        public IEnumerable<ArticleDTO> GetArticles()
        {
            var articles = _articleRepository.GetAll();
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public void AddArticle(ArticleDTO article)
        {
            _articleRepository.Create(_mapper.Map<ArticleEntity>(article));
        }
    }
}
