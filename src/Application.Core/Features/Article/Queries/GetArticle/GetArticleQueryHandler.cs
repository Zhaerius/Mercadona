using Application.Core.Dtos;
using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ArticleResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _dbContext
                .Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return _mapper.Map<ArticleResponse>(article);
        }
    }
}
