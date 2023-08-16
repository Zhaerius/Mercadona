using Application.Core.Features.Category.Commands.CreateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Commands.CreateCategories
{
    public class CreateCategoriesCommand : IRequest
    {
        public required IEnumerable<CreateCategoryCommand> Categories { get; set; }
    }
}
