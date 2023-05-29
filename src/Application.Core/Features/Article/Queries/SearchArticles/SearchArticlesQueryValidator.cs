using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Core.Features.Article.Queries.SearchArticles
{
    public class SearchArticlesQueryValidator : AbstractValidator<SearchArticlesQuery>
    {
        public SearchArticlesQueryValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(2, 12);
        }
    }
}
