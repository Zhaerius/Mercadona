using Application.Core.Entities;
using Application.Core.Extensions;
using Application.Core.Interfaces;
using Application.Core.Validations.Article;
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
        //private readonly IValidator<CreateArticleCommand> _validator;

        public CreateArticleCommandHandler(IApplicationDbContext dbContext /*IValidator<CreateArticleCommand> validator*/)
        {
            _dbContext = dbContext;
            //_validator = validator;
        }

        public async Task<string> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            //_validator.ValidateBasic(request);

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
