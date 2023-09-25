using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using MediatR;

namespace Application.Core.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _dbContext
                .Categories
                .FindAsync(request.Id) ?? throw new NotFoundException();

            _dbContext.Categories.Remove(categoryToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
