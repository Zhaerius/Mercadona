using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name): IRequest
    {
    }
}
