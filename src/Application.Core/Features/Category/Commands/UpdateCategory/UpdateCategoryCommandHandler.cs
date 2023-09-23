using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _dbContext.Categories.FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            categoryToUpdate.Name = request.Name;

            _dbContext.Categories.Update(categoryToUpdate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
