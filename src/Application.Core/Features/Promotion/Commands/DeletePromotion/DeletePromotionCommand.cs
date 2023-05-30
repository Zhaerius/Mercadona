using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.DeletePromotion
{
    public record DeletePromotionCommand(Guid Id): IRequest
    {
    }
}
