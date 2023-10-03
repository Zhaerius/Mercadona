using Application.Core.Abstractions;
using Application.Core.Entities;
using MediatR;

namespace Application.Core.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = new CategoryEntity() { Name = request.Name};

            await _dbContext.Categories.AddAsync(categoryToCreate); 
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
