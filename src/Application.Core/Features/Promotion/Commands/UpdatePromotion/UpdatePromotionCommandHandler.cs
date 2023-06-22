using Application.Core.Abstractions;
using Application.Core.Entities;
using Application.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.UpdatePromotion
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdatePromotionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToUpdate = await _dbContext.Promotions.FindAsync(request.Id) ?? throw new NotFoundException();

            promotionToUpdate.Name = request.Name;
            promotionToUpdate.Start = request.Start;
            promotionToUpdate.End = request.End;
            promotionToUpdate.Discount = request.Discount;

            _dbContext.Promotions.Update(promotionToUpdate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
