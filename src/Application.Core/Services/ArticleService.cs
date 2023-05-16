using Application.Core.Dtos;
using Application.Core.Entities;
using Application.Core.Interfaces;
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
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public ArticleDto GetArticle(Guid id)
        {
            var article = _dbContext.Articles.Find(id);
            return _mapper.Map<ArticleDto>(article);
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            var articles = _dbContext.Articles;
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public void AddArticle(ArticleDto ArticleDto)
        {
            var article = _mapper.Map<ArticleEntity>(ArticleDto);
            _dbContext.Articles.Add(article);
            _dbContext.SaveChangesAsync();
        }


    }
}
