using Application.Core.Features.Category.Commands.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Commands.CreateCategories
{
    public class CreateCategoriesCommandValidator : AbstractValidator<CreateCategoriesCommand>
    {
        public CreateCategoriesCommandValidator()
        {
            RuleFor(c => c.Categories)
                .NotEmpty()
                .NotNull();

            RuleForEach(c => c.Categories)
                .SetValidator(new CreateCategoryCommandValidator());
        }
    }
}
