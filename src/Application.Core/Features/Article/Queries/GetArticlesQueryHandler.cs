using Application.Core.Dtos;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries
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

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery query, CancellationToken cancellationToken)
        {
            var articles = _dbContext.Articles;
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }
    }
}
