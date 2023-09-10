using Application.Core.Entities;
using Application.Core.Abstractions;
using FluentValidation;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = _mapper.Map<ArticleEntity>(request);

            if (request.PromotionsIds is not null && request.PromotionsIds.Any())
            {
                var promotions = await _dbContext.Promotions
                    .Where(p => request.PromotionsIds.Contains(p.Id))
                    .ToListAsync();

                article.Promotions = promotions;
            }

            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}
