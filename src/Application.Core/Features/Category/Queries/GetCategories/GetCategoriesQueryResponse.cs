using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Queries.GetCategories
{
    public record GetCategoriesQueryResponse(Guid Id, string Name)
    {
    }
}
