using Application.Core.Abstractions;
using Application.Core.Entities;
using Application.Core.Features.Category.Commands.CreateCategory;
using MediatR;

namespace Application.Core.Features.Category.Commands.CreateCategories
{
    public class CreateCategoriesCommandHandler : IRequestHandler<CreateCategoriesCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCategoriesCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Categories)
            {
                var categoryToCreate = new CategoryEntity() { Name = item.Name };
                await _dbContext.Categories.AddAsync(categoryToCreate);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
