using Application.Core.Abstractions;
using Application.Core.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.CreatePromotion
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePromotionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToCreate = _mapper.Map<PromotionEntity>(request);

            await _dbContext.Promotions.AddAsync(promotionToCreate);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return promotionToCreate.Id;
        }
    }
}
