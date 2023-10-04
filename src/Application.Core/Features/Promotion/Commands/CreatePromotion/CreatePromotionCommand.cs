using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.CreatePromotion
{
    public record CreatePromotionCommand(string Name, DateOnly Start, DateOnly End, int Discount) : IRequest<Guid>
    {
    }
}
