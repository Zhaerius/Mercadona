using Application.Core.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCategoryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(c => c.Id).MustAsync(async (entity, value, c) => await CategoryEmpty(value)).WithMessage("Supression impossible, la catégorie contien des articles");
        }

        public async Task<bool> CategoryEmpty(Guid id)
        {
            var articles = await _dbContext.Articles.Where(a => a.CategoryId == id).ToListAsync();
            if (articles.Any())
                return false;
            return true;
        }
    }
}
