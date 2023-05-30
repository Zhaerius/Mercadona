using MediatR;


namespace Application.Core.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<GetCategoriesQueryResponse>>
    {
    }
}
