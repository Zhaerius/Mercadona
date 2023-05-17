using Application.Core.Dtos;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<ArticleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetArticlesQueryHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _dbContext.Articles.ToListAsync();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }
    }
}
