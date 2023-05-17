using Application.Core.Dtos;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _dbContext.Articles.FindAsync(request.Id);
            return _mapper.Map<ArticleDto>(article);
        }
    }
}
