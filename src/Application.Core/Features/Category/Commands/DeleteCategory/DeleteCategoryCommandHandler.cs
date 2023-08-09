using Application.Core.Abstractions;
using Application.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var CategoryToDelete = await _dbContext
                .Categories
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            _dbContext.Categories.Remove(CategoryToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
