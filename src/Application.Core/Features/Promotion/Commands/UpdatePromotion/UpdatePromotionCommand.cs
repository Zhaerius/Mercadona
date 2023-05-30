using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.UpdatePromotion
{
    public record UpdatePromotionCommand(Guid Id, string Name, DateOnly Start, DateOnly End, int Discount) : IRequest
    {
    }
}
