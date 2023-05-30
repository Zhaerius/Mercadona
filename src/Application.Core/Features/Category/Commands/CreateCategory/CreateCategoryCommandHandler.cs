using Application.Core.Abstractions;
using Application.Core.Entities;
using Application.Core.Exceptions;
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
            if (string.IsNullOrWhiteSpace(request.Name)) throw new ValidationException();

            var categoryToCreate = new CategoryEntity() { Name = request.Name};

            await _dbContext.Categories.AddAsync(categoryToCreate); 
            await _dbContext.SaveChangesAsync();
        }
    }
}
