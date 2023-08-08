using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(article => article.Name).NotNull().NotEmpty();
            RuleFor(article => article.Description).NotNull().NotEmpty();
            RuleFor(article => article.BasePrice).NotNull().NotEmpty();
            RuleFor(article => article.Image).NotNull().NotEmpty();
            RuleFor(article => article.CategoryId).NotNull().NotEmpty();
            RuleFor(article => article.Publish).NotNull().NotEmpty();
        }
    }
}