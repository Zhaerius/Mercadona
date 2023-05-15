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


        public ArticleDto GetArticle(Guid id)
        {
            var article = _articleRepository.GetById(id);
            return _mapper.Map<ArticleDto>(article);
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            var articles = _articleRepository.GetAll();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public void AddArticle(ArticleDto ArticleDto)
        {
            var article = _mapper.Map<ArticleEntity>(ArticleDto);
            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
        }


    }
}
