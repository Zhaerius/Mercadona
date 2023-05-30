using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(Guid Id, string Name): IRequest
    {
    }
}
