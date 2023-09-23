using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using MediatR;

namespace Application.Core.Features.Promotion.Commands.DeletePromotion
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeletePromotionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToDelete = await _dbContext
                .Promotions
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            _dbContext.Promotions.Remove(promotionToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
