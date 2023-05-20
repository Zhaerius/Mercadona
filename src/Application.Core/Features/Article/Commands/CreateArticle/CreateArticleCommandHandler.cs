using Application.Core.Entities;
using Application.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateArticleCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new ArticleEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return article.Name;

        }
    }
}
