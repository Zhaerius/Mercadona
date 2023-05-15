using Application.Core.Dtos;
using Application.Core.Interfaces.Repositories;
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
        private readonly IArticleRepository _articleRepository;

        public GetArticlesQueryHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery query, CancellationToken cancellationToken)
        {
            var articles = _articleRepository.GetAll();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }
    }
}
