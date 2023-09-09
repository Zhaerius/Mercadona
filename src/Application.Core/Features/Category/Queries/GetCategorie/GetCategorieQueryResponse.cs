using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Category.Queries.GetCategorie
{
    public record GetCategorieQueryResponse(Guid Id, string Name)
    {
    }
}
